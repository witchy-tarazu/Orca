using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Orca
{
    public class CustomController : MonoBehaviour
    {
        private enum ControllerState
        {
            Inactive,
            Active,
        }

        private enum SelectionMode
        {
            Piece,
            Legacy,
        }

        [field: SerializeField]
        private CustomPieceLauncher Launcher { get; set; }
        [field: SerializeField]
        private Animator Animator { get; set; }

        public ActorHealth ActorHealth { get; set; }
        public List<MasterLegacy> LegacyList { get; set; }
        private Action<List<MasterCard>> StartTurnCallback { get; set; }

        private MemoryDatabase Database { get; set; }
        private CustomInputContainer InputContainer { get; set; }

        private CustomPieceController PieceController { get; set; }

        private ControllerState State { get; set; }
        private SelectionMode Mode { get; set; }

        private void Start()
        {
            State = ControllerState.Inactive;
            PieceController = new(
                prefab => Instantiate(prefab, transform).GetComponent<CustomPieceBehaviour>(),
                Destroy,
                Launcher.Launch);
        }

        public void Setup(
            MemoryDatabase database,
            CustomInputContainer inputContainer,
            ActorHealth actorHealth,
            List<MasterPiece> deck,
            List<MasterLegacy> legacyList,
            Action<List<MasterCard>> startTurnCallback)
        {
            Database = database;
            InputContainer = inputContainer;
            ActorHealth = actorHealth;
            LegacyList = legacyList;
            StartTurnCallback = startTurnCallback;

            PieceController.Setup(database, inputContainer, deck);

            State = ControllerState.Inactive;
        }

        public void Open()
        {
            PlayOpenAnimation();
        }

        private void DrawPieces()
        {
            State = ControllerState.Active;
            Mode = SelectionMode.Piece;
            PieceController.Draw(ActorHealth.GetStackValue(ActorState.Charge));
        }

        public void StartTurn()
        {
            StartTurnCallback.Invoke(PieceController.CreateCardList());
            PieceController.PrepareForNextTurn();
        }

        private void Update()
        {
            switch (State)
            {
                case ControllerState.Inactive:
                    return;
            }

            switch (InputContainer.CustomCommand)
            {
                case CustomCommand.Decide:
                    PlayDecideAnimation();
                    return;
            }

            switch (Mode)
            {
                case SelectionMode.Piece:
                    PieceController.Update();
                    break;
                case SelectionMode.Legacy:
                    break;
            }
        }

        private void PlayOpenAnimation()
        {
            Animator.Play("Open");
        }

        private void PlayDecideAnimation()
        {
            Animator.Play("Close");
        }
    }
}