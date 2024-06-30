using System;
using System.Collections.Generic;
using System.Linq;

namespace Orca
{
    public class BattleStage
    {
        public int WidthPerPanel { get; private set; }

        private HashSet<Panel> Panels { get; set; }

        public BattleStage(List<MasterStage> master, int widthPerPanel)
        {
            for (int i = 0; i < master.Count; i++)
            {
                var panelData = master[i];
                Panels.Add(new(panelData.PanelType, new PanelPosition(panelData.PanelIndex)));
            }

            WidthPerPanel = widthPerPanel;
        }

        public void AddHealth(PanelPosition position, ActorHealth health)
        {
            var panel = GetPanel(position);
            panel.Add(health);
        }

        /// <summary>
        /// ステージ内か
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsValidPos(PanelPosition position)
        {
            return position.PositionX >= 0 && position.PositionX < Panels.Count;
        }

        public bool TryMove(PanelPosition position, ActorHealth ownerHealth, Action onCancel)
        {
            if (!IsValidPos(position))
            {
                onCancel.Invoke();
                return false;
            }

            var targetPanel = GetPanel(position);
            var ownerPanel = GetPanel(ownerHealth);
            if (targetPanel.Position == ownerPanel.Position)
            {
                return false;
            }

            var opponentSide = ownerHealth.Side == ActorSide.Left ? ActorSide.Right : ActorSide.Left;
            if (targetPanel.HasAnyActor(opponentSide))
            {
                onCancel.Invoke();
                return false;
            }

            ownerPanel.Remove(ownerHealth);
            targetPanel.Add(ownerHealth);

            return true;
        }

        /// <summary>
        /// 穴が開いているか
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool IsPitfall(PanelPosition position)
        {
            var panel = Panels.First(x => x.Position == position);
            return panel.Type == PanelType.Hall;
        }

        public PanelPosition GetPanelPosition(int linearPosition)
        {
            return new PanelPosition(linearPosition / WidthPerPanel);
        }

        public int GetLinearPositonCenter(PanelPosition panelPosition)
        {
            int zeroPosition = -WidthPerPanel * (Panels.Count - 1) / 2;
            int currentIndex = Panels
                .OrderBy(panel => panel.Position.PositionX)
                .ToList()
                .FindIndex(panel => panel.Position == panelPosition);

            return zeroPosition + currentIndex * WidthPerPanel;
        }

        public int GetLinearPositonEdge(PanelPosition panelPosition, ActorSide side)
        {
            int result = GetLinearPositonCenter(panelPosition);

            result = side switch
            {
                ActorSide.Left => result + WidthPerPanel / 2 - 1,
                ActorSide.Right => result - WidthPerPanel / 2 + 1,
                _ => result,
            };

            return result;
        }

        public HashSet<PanelPosition> GetPanelPositions(
            ActorHealth ownerHealth,
            PanelPosition ownerPosition,
            MasterInfluence masterInfluence)
        {
            return masterInfluence.TargetType switch
            {
                InfluenceTargetType.RelativePosition => GetRelativePanelPositions(ownerHealth, ownerPosition, masterInfluence),
                InfluenceTargetType.AbsolutePosition => GetAbsolutePanelPositions(ownerHealth, masterInfluence),
                _ => null,// SelfとWholeはパネル情報が要らず、Positionはこの関数を必要としない
            };
        }

        private HashSet<PanelPosition> GetRelativePanelPositions(
           ActorHealth ownerHealth,
           PanelPosition ownerPosition,
           MasterInfluence masterInfluence)
        {
            var positions = GetPanelPositionsByMaster(masterInfluence);

            switch (ownerHealth.Side)
            {
                case ActorSide.Left:
                default:
                    return positions
                        .Select(position => new PanelPosition(ownerPosition.PositionX + position.PositionX))
                        .Where(position => IsValidPos(position))
                        .ToHashSet();
                case ActorSide.Right:
                    return positions
                        .Select(position => new PanelPosition(ownerPosition.PositionX - position.PositionX))
                        .Where(position => IsValidPos(position))
                        .ToHashSet();
            }
        }

        private HashSet<PanelPosition> GetAbsolutePanelPositions(
           ActorHealth ownerHealth,
           MasterInfluence masterInfluence)
        {
            var positions = GetPanelPositionsByMaster(masterInfluence);
            switch (ownerHealth.Side)
            {
                case ActorSide.Left:
                default:
                    return positions
                        .Where(position => IsValidPos(position))
                        .ToHashSet();
                case ActorSide.Right:
                    return positions
                        .Select(position => new PanelPosition(Panels.Count - 1 - position.PositionX))
                        .Where(position => IsValidPos(position))
                        .ToHashSet();
            }
        }

        private HashSet<PanelPosition> GetPanelPositionsByMaster(MasterInfluence masterInfluence)
        {
            HashSet<PanelPosition> result = new();

            for (int i = masterInfluence.CheckValueMin; i <= masterInfluence.CheckValueMax; i++)
            {
                result.Add(new PanelPosition(i));
            }

            return result;
        }


        public Panel GetPanel(PanelPosition position)
        {
            return Panels.Where(panel => panel.Position == position).FirstOrDefault();
        }

        public Panel GetPanel(ActorHealth health)
        {
            return Panels.Where(panel => panel.HasActor(health)).FirstOrDefault();
        }

        public HashSet<Panel> GetAllPanelHasActor()
        {
            return Panels.Where(panel => panel.HasAnyActor()).ToHashSet();
        }

        public Panel GetNearestPanel(CheckData check)
        {
            Panel panel = null;

            check.ApplyToPositions(
                position =>
                {
                    var tmp = GetPanel(position);

                    var checkSide = check.CheckSide;
                    if (checkSide == InfluenceCheckSide.Whole)
                    {
                        if (tmp.HasAnyActor()
                            && IsNearest(check.OwnerHealth.Side, tmp, panel))
                        {
                            panel = tmp;
                        }
                    }

                    var side = checkSide switch
                    {
                        InfluenceCheckSide.Owner =>
                             check.OwnerHealth.Side == ActorSide.Left ? ActorSide.Left : ActorSide.Right,
                        InfluenceCheckSide.Opponent =>
                            check.OwnerHealth.Side == ActorSide.Left ? ActorSide.Right : ActorSide.Left,
                        _ => ActorSide.Left,
                    };

                    if (tmp.HasAnyActor(side) && IsNearest(side, tmp, panel))
                    {
                        panel = tmp;
                    }
                });

            return panel;
        }

        private bool IsNearest(ActorSide side, Panel tmp, Panel current)
        {
            if (current == null)
            {
                return true;
            }

            if (side == ActorSide.Left
                && tmp.Position.PositionX < current.Position.PositionX)
            {
                return true;
            }

            if (side == ActorSide.Right
                && tmp.Position.PositionX > current.Position.PositionX)
            {
                return true;
            }

            return false;
        }

        public Panel GetNearestEnemyPanel(ActorHealth health)
        {
            var currentPanel = GetPanel(health);
            switch (health.Side)
            {
                case ActorSide.Left:
                    return Panels
                        .Where(x => x.Position.PositionX > currentPanel.Position.PositionX)
                        .OrderBy(x => x.Position.PositionX)
                        .First();
                case ActorSide.Right:
                    return Panels
                        .Where(x => x.Position.PositionX < currentPanel.Position.PositionX)
                        .OrderByDescending(x => x.Position.PositionX)
                        .First();
                default:
                    return null;
            }
        }
    }
}