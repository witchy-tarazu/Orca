using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Orca
{
    public class ChildInfluencer
    {
        public bool IsSatisfied { get; private set; }

        public PanelPosition Position { get; private set; }

        public MasterInfluenceRelation MasterInfluenceRelation { get; set; }

        public MasterInfluence MasterInfluence { get; private set; }

        public ChildInfluencer(ActorHealth ownerHealth, MasterInfluenceRelation masterInfluenceRelation, MasterInfluence masterInfluence)
        {
            IsSatisfied = false;
            MasterInfluenceRelation = masterInfluenceRelation;
            MasterInfluence = masterInfluence;
        }

        public void CheckSatisfaction(ChildTriggerCondition triggerCondition, PanelPosition position)
        {
            if (MasterInfluenceRelation.TriggerCondition == triggerCondition)
            {
                IsSatisfied = true;
                Position = position;
            }
        }
    }
}