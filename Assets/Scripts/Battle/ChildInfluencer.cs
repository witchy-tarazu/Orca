using System;
using System.Collections.Generic;

namespace Orca
{
    public class ChildInfluencer
    {
        public bool IsSatisfied { get; private set; }

        public MasterChildInfluence Master { get; set; }

        private HashSet<ActorHealth> SatisfiedHealthSet { get; set; }

        public ChildInfluencer(MasterChildInfluence masterChild)
        {
            IsSatisfied = false;
            Master = masterChild;
        }

        public void CheckSatisfaction(ChildTriggerCondition triggerCondition, ActorHealth health)
        {
            if (Master.TriggerCondition == triggerCondition)
            {
                IsSatisfied = true;
                SatisfiedHealthSet.Add(health);
            }
        }

        public void CheckSatisfaction(ChildTriggerCondition triggerCondition, HitData hitData)
        {
            if (Master.TriggerCondition == triggerCondition)
            {
                IsSatisfied = true;
                hitData.ApplyToActors(health => SatisfiedHealthSet.Add(health));
            }
        }

        public HitProcessData CreateHitProcessData(HitData hitData, ActorHealth ownerHealth)
        {
            HitProcessData processData =
                new(Master.InfluenceType,
                    Master.ActorState,
                    Master.PenetrationType,
                    Master.Value,
                    hitData,
                    ownerHealth,
                    null,
                    0);

            return processData;
        }
    }
}