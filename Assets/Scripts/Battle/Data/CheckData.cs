using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Orca
{
    public struct CheckData
    {
        private HashSet<PanelPosition> CheckPositions { get; set; }

        public ActorHealth OwnerHealth { get; private set; }

        public InfluenceCheckSide CheckSide { get; private set; }

        public InfluenceCheckTargetType CheckTargetType { get; private set; }

        public InfluenceCheckRangeType CheckRangeType { get; private set; }


        public CheckData(
            HashSet<PanelPosition> positions,
            ActorHealth ownerHealth,
            InfluenceCheckSide side, InfluenceCheckTargetType type, InfluenceCheckRangeType targetType)
        {
            CheckPositions = positions;
            OwnerHealth = ownerHealth;
            CheckSide = side;
            CheckTargetType = type;
            CheckRangeType = targetType;
        }

        public void ApplyToPositions(Action<PanelPosition> action)
        {
            foreach (var position in CheckPositions)
            {
                action.Invoke(position);
            }
        }
    }
}