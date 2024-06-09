using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class BattleCallbackContainer
    {
        private Action<int> CheckCallback { get; set; }
        private Action<HitData> HitCallback { get; set; }
        private Action ReleaseCallback { get; set; }

        public BattleCallbackContainer(Action<int> checkCallback, Action<HitData> hitCallback, Action releaseCallback)
        {
            CheckCallback = checkCallback;
            HitCallback = hitCallback;
            ReleaseCallback = releaseCallback;
        }

        public void Check(int value)
        {
            CheckCallback.Invoke(value);
        }

        public void Hit(HitData hit)
        {
            HitCallback.Invoke(hit);
        }

        public void Release()
        {
            ReleaseCallback.Invoke();
        }
    }
}