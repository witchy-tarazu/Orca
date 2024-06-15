using System;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class HitData : MonoBehaviour
    {
        public Panel Panel { get; private set; }

        private HashSet<ActorHealth> HitList { get; set; }

        public HitData(Panel panel, HashSet<ActorHealth> hitList)
        {
            Panel = panel;
            HitList = hitList;
        }

        public void ApplyToActors(Action<ActorHealth> action)
        {
            foreach (var actor in HitList)
            {
                action(actor);
            }
        }
    }
}