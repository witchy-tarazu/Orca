using System;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class HitData : MonoBehaviour
    {
        private List<ActorHealth> HitList { get; set; }

        public HitData(List<ActorHealth> hitList)
        {
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