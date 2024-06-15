using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public enum ActorSide
    {
        Left,
        Right,
    }

    public class Actor : IUpdatable
    {
        private ActorAction Action { get; set; }
        private ActorCard Card { get; set; }
        private ActorHealth Health { get; set; }

        private BattleStage Stage { get; set; }

        private Action<CheckData> CheckCallback { get; set; }

        private Action<Actor> OnDeadCallback { get; set; }

        public void Update()
        {

        }
    }
}