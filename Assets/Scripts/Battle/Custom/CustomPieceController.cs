using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Orca
{
    public enum CustomPieceControlMode
    {
        Selection,
        Mergence,
        Override,
    }

    public class CustomPieceController
    {
        private bool IsControlLocked { get; set; }

        public List<MasterPiece> Deck { get; set; }

        private Queue<MasterPiece> DeckMasterQueue { get; set; }

        private List<CustomPieceBehaviour> PieceList { get; set; }
        private List<CustomPieceBehaviour> TakeoverPieceList { get; set; }
        private List<CustomPieceBehaviour> SelectedPieceList { get; set; }

        private MemoryDatabase Database { get; set; }
        private CustomInputContainer InputContainer { get; set; }

        private Object PiecePrefab { get; set; }

        private ObjectPool<CustomPieceBehaviour> PiecePool { get; set; }

        private CustomPieceControlMode Mode { get; set; }

        private CustomPieceBehaviour MergenceSource { get; set; }

        private CustomPieceBehaviour CurrentPiece { get; set; }

        private Action<List<CustomPieceBehaviour>, List<CustomPieceBehaviour>, Action> LaunchAction { get; set; }

        private Action<CustomPieceBehaviour> OverrideSelection { get; set; }
        private Action OverrideCancellation { get; set; }

        public CustomPieceController(
            Func<Object, CustomPieceBehaviour> instantiateFunc,
            Action<MonoBehaviour> destroy,
            Action<List<CustomPieceBehaviour>, List<CustomPieceBehaviour>, Action> launchAction)
        {
            PiecePrefab = Resources.Load("Orca/Prefabs/CustomPiece");

            DeckMasterQueue = new();
            PieceList = new();
            PiecePool = new(
                () => instantiateFunc(PiecePrefab),
                actionOnGet: piece =>
                {
                    piece.Invalidate();
                    PieceList.Add(piece);
                },
                actionOnRelease: piece =>
                {
                    PieceList.Remove(piece);
                },
                actionOnDestroy: piece => destroy(piece),
                defaultCapacity: BattleDefine.MaxCustomPieceCount);
            TakeoverPieceList = new();

            LaunchAction = launchAction;
        }

        public void Setup(
            MemoryDatabase database,
            CustomInputContainer inputContainer,
            List<MasterPiece> deck)
        {
            Database = database;
            InputContainer = inputContainer;
            Deck = deck;

            DeckMasterQueue.Clear();
            PiecePool.Clear();
            PieceList.Clear();
            TakeoverPieceList.Clear();

            Mode = CustomPieceControlMode.Selection;
            MergenceSource = null;
            CurrentPiece = null;

            ResetOverrideAction();
            Reload();
        }

        public void Draw(int chargeCount)
        {
            // éËéDÇÃñáêî
            int handNum = BattleDefine.DefaultCustomDrawCount + chargeCount;
            handNum = Mathf.Min(handNum, BattleDefine.MaxCustomPieceCount);
            handNum = Mathf.Min(handNum, DeckMasterQueue.Count);

            int drawNum = handNum - TakeoverPieceList.Count;
            List<CustomPieceBehaviour> drawPieceList = new();
            for (int i = 0; i < drawNum; i++)
            {
                var piece = PiecePool.Get();
                var master = DeckMasterQueue.Dequeue();
                piece.Setup(master, Database);
                drawPieceList.Add(piece);
            }
            drawPieceList.InsertRange(0, TakeoverPieceList);

            CurrentPiece = drawPieceList.LastOrDefault();

            LockControl();
            LaunchAction.Invoke(drawPieceList, PieceList, UnlockControl);
        }

        private void AddPiece(List<MasterPiece> masterList)
        {
            List<CustomPieceBehaviour> drawPieceList = new();
            for (int i = 0; i < masterList.Count; i++)
            {
                var piece = PiecePool.Get();
                piece.Setup(masterList[i], Database);
                drawPieceList.Add(piece);
            }

            LockControl();
            LaunchAction.Invoke(drawPieceList, PieceList, UnlockControl);
        }

        private void Merge(CustomPieceBehaviour source, CustomPieceBehaviour target)
        {
            target.LevelUp();
            source.Invalidate();
        }

        private void Reload()
        {
            DeckMasterQueue = new(Deck.OrderBy(master => Random.Range(0, int.MaxValue)));
        }

        public void SelectPiece(CustomPieceBehaviour piece)
        {
            switch (Mode)
            {
                case CustomPieceControlMode.Selection:
                    if (SelectedPieceList.Contains(piece))
                    {
                        SelectedPieceList.Remove(piece);
                        LaunchAction.Invoke(new() { piece }, PieceList, UnlockControl);
                    }
                    else
                    {
                        SelectedPieceList.Add(piece);
                        piece.gameObject.SetActive(false);
                    }
                    break;
                case CustomPieceControlMode.Mergence:
                    if (piece == MergenceSource)
                    {
                        CancelMergence();
                    }
                    else
                    {
                        Merge(MergenceSource, piece);
                    }
                    break;
                case CustomPieceControlMode.Override:
                    OverrideSelection?.Invoke(piece);
                    break;
            }
        }

        public void SwitchMergence(CustomPieceBehaviour piece)
        {
            Mode = CustomPieceControlMode.Mergence;
            MergenceSource = piece;

            PieceList.ForEach(piece => piece.UpdateMergeVisual(MergenceSource));
        }

        public void CancelMergence()
        {
            Mode = CustomPieceControlMode.Selection;
            MergenceSource = null;

            PieceList.ForEach(piece => piece.ResetVisual());
        }

        public List<MasterCard> CreateCardList()
        {
            List<MasterCard> cardList = SelectedPieceList
                .Select(piece =>
                {
                    var relation = Database.MasterPieceRelationTable.FindByPieceIdAndGrade((piece.Master.PieceId, piece.Grade));
                    return Database.MasterCardTable.FindByCardId(relation.CardId);
                }).ToList();
            return cardList;
        }

        public void PrepareForNextTurn()
        {
            DeckMasterQueue.Clear();
            SelectedPieceList.ForEach(piece => PiecePool.Release(piece));
            SelectedPieceList.Clear();
            TakeoverPieceList = new(PieceList);
            MergenceSource = null;
        }

        private void LockControl()
        {
            IsControlLocked = true;
        }

        private void UnlockControl()
        {
            IsControlLocked = false;
        }

        public void Update()
        {
            if (IsControlLocked) { return; }
            if (CurrentPiece == null) { return; }

            switch (InputContainer.CustomCommand)
            {
                case CustomCommand.Cancel:
                    Cancel();
                    return;
                case CustomCommand.Select:
                    SelectPiece(CurrentPiece);
                    return;
                case CustomCommand.Merge:
                    ProcessCommandMerge();
                    return;
            }

            switch (InputContainer.DirectionCommand)
            {
                case DirectionCommand.Left:
                    CurrentPiece = CurrentPiece.LeftPiece ?? CurrentPiece;
                    break;
                case DirectionCommand.Right:
                    CurrentPiece = CurrentPiece.RightPiece ?? CurrentPiece;
                    break;
                case DirectionCommand.Up:
                    CurrentPiece = CurrentPiece.UpPiece ?? CurrentPiece;
                    break;
                case DirectionCommand.Down:
                    CurrentPiece = CurrentPiece.DownPiece ?? CurrentPiece;
                    break;
            }
        }

        private void Cancel()
        {
            switch (Mode)
            {
                case CustomPieceControlMode.Selection:
                    if (SelectedPieceList.Count > 0)
                    {
                        SelectPiece(SelectedPieceList[SelectedPieceList.Count - 1]);
                    }
                    break;
                case CustomPieceControlMode.Mergence:
                    CancelMergence();
                    break;
                case CustomPieceControlMode.Override:
                    OverrideCancellation?.Invoke();
                    break;
            }
        }

        private void ProcessCommandMerge()
        {
            switch (Mode)
            {
                case CustomPieceControlMode.Mergence:
                    Cancel();
                    return;
                case CustomPieceControlMode.Override:
                    return;
            }

            if (CurrentPiece.CanLevelUp()
                        && PieceList.Any(piece => piece.CanMerge(CurrentPiece)))
            {
                SwitchMergence(CurrentPiece);
            }
        }

        public void Override(Action<CustomPieceBehaviour> select, Action cancel, Action<CustomPieceBehaviour> updateVisual)
        {
            Mode = CustomPieceControlMode.Override;
            OverrideSelection = select;
            OverrideCancellation = cancel;
            PieceList.ForEach(piece => updateVisual.Invoke(piece));
        }

        public void ResetOverrideAction()
        {
            OverrideSelection = null;
            OverrideCancellation = null;
            PieceList.ForEach(piece => piece.ResetVisual());
        }
    }
}