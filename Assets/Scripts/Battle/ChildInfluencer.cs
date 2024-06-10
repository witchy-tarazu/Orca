using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public enum ChildTriggerCondition
    {
        None = 0,
        Hit,
        NoHit,
        Damage,
        NoDamage,
    }

    public class ChildInfluencer
    {
        public bool IsSatisfied { get; set; }
        public int ExecuteFrameOffset { get; private set; }
        public int AdditionalFinishFrame { get; private set; }
        public Influencer Influencer { get; private set; }
        public ChildTriggerCondition Condition { get; private set; }

        public ChildInfluencer(
            int excuteFrameOffset,
            int additionalFinishFrame,
            Influencer influencer,
            ChildTriggerCondition condition)
        {
            ExecuteFrameOffset = excuteFrameOffset;
            AdditionalFinishFrame = additionalFinishFrame;
            Influencer = influencer;
            Condition = condition;
        }
    }
}