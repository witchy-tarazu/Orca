using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public struct CheckData
    {
        public int CheckValue { get; private set; }

        public CheckSide CheckSide { get; private set; }

        public CheckRange CheckRange { get; private set; }

        public CheckType CheckType { get; private set; }


        public CheckData(int checkValue, CheckSide side, CheckRange range, CheckType type)
        {
            CheckValue = checkValue;
            CheckSide = side;
            CheckType = type;
            CheckRange = range;
        }
    }
}