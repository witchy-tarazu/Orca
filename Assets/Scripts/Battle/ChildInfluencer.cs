using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Orca
{
    public class ChildInfluencer
    {
        public bool IsSatisfied { get; private set; }

        public MasterChildInfluence Master { get; set; }

        public ChildInfluencer(ActorHealth ownerHealth, MasterChildInfluence masterChild)
        {
            IsSatisfied = false;
            Master = masterChild;
        }

        public void CheckSatisfaction(ChildTriggerCondition triggerCondition)
        {
            if (Master.TriggerCondition == triggerCondition)
            {
                IsSatisfied = true;
            }
        }
    }
}