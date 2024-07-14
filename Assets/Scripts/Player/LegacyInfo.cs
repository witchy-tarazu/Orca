using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class LegacyInfo
    {
        public MasterLegacy Master { get; private set; }
        public int UsableCount { get; private set; }

        public LegacyInfo(MasterLegacy master, int usableCount)
        {
            Master = master;
            UsableCount = usableCount;
        }
    }
}