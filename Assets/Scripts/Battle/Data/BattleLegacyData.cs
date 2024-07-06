using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class BattleLegacyData
    {
        public int LegacyId { get; }
        private int UsedCount { get; set; }

        public void Use()
        {
            UsedCount++;
        }

        public bool CanUse()
        {
            return true;
        }
    }
}