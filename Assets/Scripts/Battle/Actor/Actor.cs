using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class Actor
    {
        private Stage stage { get; set; }

        private ActorAction action { get; set; }
        private ActorCard card { get; set; }
        private ActorHp hp { get; set; }
        private ActorStatus status { get; set; }

        public void Update()
        {

        }
    }
}