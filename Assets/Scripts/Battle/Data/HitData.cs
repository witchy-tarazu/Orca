using System;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class HitData : MonoBehaviour
    {
        private List<Actor> hitActors;

        public HitData(List<Actor> hitActors)
        {
            this.hitActors = hitActors;
        }

        public void ApplyToActors(Action<Actor> action)
        {
            foreach (var actor in hitActors)
            {
                action(actor);
            }
        }
    }
}