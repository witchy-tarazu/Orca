using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public enum ActorSide
    {
        Left,
        Right,
    }

    public enum CheckType
    {
        Position,
        PanelIndex,
    }

    public enum RangeType
    {
        Single,
        Panel,
        Whole,
    }


    public struct CheckData
    {
        public int CheckValue { get; private set; }

        public ActorSide OwnerSide { get; private set; }

        public CheckType CheckType { get; private set; }


        public CheckData(int checkValue, ActorSide side, CheckType checkType)
        {
            CheckValue = checkValue;
            OwnerSide = side;
            CheckType = checkType;
        }
    }
}