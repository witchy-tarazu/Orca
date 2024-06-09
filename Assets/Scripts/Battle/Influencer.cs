using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class Influencer
    {
        private int CurrentFrame { get; set; }

        private int EndFrame { get; set; }

        private int ParentIndex { get; set; }

        private List<int> RelativeInfluenceIndexes { get; set; }

        private BattleCallbackContainer CallbackContainer { get; set; }

        public Influencer(
            int endFrame,
            int parentIndex,
            List<int> relativeInfluenceIndexes,
            BattleCallbackContainer callbackContainer)
        {
            CurrentFrame = 0;
            EndFrame = endFrame;
            ParentIndex = parentIndex;
            RelativeInfluenceIndexes = relativeInfluenceIndexes;
            CallbackContainer = callbackContainer;
        }

        public void Update()
        {
            CurrentFrame++;

            foreach (var panelIndex in RelativeInfluenceIndexes)
            {
                CallbackContainer.Check(ParentIndex + panelIndex);
            }
        }

        public void Hit(HitData hitData)
        {
            CallbackContainer.Hit(hitData);
        }

        public void LateUpdate()
        {
            if (CurrentFrame == EndFrame)
            {
                CallbackContainer.Release();
            }
        }
    }
}