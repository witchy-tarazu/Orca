using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Orca
{
    public class ChildInfluencer
    {
        public bool IsSatisfied { get; private set; }

        public MasterChildInfluence MasterInfluenceRelation { get; set; }

        public ChildInfluencer(ActorHealth ownerHealth, MasterChildInfluence masterInfluenceRelation)
        {
            IsSatisfied = false;
            MasterInfluenceRelation = masterInfluenceRelation;
        }

        public void CheckSatisfaction(ChildTriggerCondition triggerCondition)
        {
            if (MasterInfluenceRelation.TriggerCondition == triggerCondition)
            {
                IsSatisfied = true;
            }
        }
    }
}