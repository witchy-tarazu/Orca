using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class Actor : IUpdatable
    {
        private ActorAction Action { get; set; }
        private ActorCard Card { get; set; }
        private ActorHealth Health { get; set; }

        private Action<int> TryMoveCallback { get; set; }

        private Action<CheckData> CheckCallback { get; set; }

        public void Update()
        {

        }
    }
}