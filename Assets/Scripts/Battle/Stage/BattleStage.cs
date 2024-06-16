using System;
using System.Collections.Generic;
using System.Linq;

namespace Orca
{
    public class BattleStage
    {
        private int WidthPerPanel { get; set; }

        private Dictionary<PanelPosition, Panel> Panels { get; set; }


        /// <summary>
        /// ステージ内か
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsValidPos(PanelPosition position)
        {
            return position.PositionX >= 0 && position.PositionX < Panels.Count;
        }

        /// <summary>
        /// 穴が開いているか
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool IsPitfall(PanelPosition position)
        {
            var panel = Panels[position];
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
                .OrderBy(panel => panel.Key.PositionX)
                .ToList()
                .FindIndex(panel => panel.Key == panelPosition);

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
            return Panels.Values.Where(panel => panel.Position == position).FirstOrDefault();
        }

        public Panel GetPanel(ActorHealth health)
        {
            return Panels.Values.Where(panel => panel.HasActor(health)).FirstOrDefault();
        }

        public HashSet<Panel> GetAllPanelHasActor()
        {
            return Panels.Values.Where(panel => panel.HasAnyActor()).ToHashSet();
        }

        public Panel GetNearestPanel(CheckData check)
        {
            Panel panel = null;

            check.ApplyToPositions(
                position =>
                {
                    
                });

            return panel;
        }
    }
}