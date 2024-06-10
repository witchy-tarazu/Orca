using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class BattleCallbackContainer
    {
        private Action<CheckData, IHitChecker> CheckCallback { get; set; }
        private Action<HitData> HitCallback { get; set; }
        private Action ReleaseCallback { get; set; }

        public BattleCallbackContainer(
            Action<CheckData, IHitChecker> checkCallback,
            Action<HitData> hitCallback,
            Action releaseCallback
            )
        {
            CheckCallback = checkCallback;
            HitCallback = hitCallback;
            ReleaseCallback = releaseCallback;
        }

        public void Check(CheckData data, IHitChecker checker)
        {
            CheckCallback.Invoke(data, checker);
        }

        public void Hit(HitData data)
        {
            HitCallback.Invoke(data);
        }

        public void Release()
        {
            ReleaseCallback.Invoke();
        }
    }
}