using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class ActorHealth
    {
        public ActorStatus Status { get; private set; }
        public ActorHitPoint Health { get; private set; }

        public ActorHealth(ActorStatus status, ActorHitPoint health)
        {
            Status = status;
            Health = health;
        }
    }
}