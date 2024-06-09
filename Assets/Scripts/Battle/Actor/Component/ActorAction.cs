using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class ActorAction
    {
        private int currentFrame { get; set; }

        public void Execute(BattleCard card)
        {
            currentFrame = 0;
        }

        public void Update()
        {
            currentFrame++;
        }

        public void Cancel()
        {

        }
    }
}