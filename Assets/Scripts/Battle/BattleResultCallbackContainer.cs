using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class BattleResultCallbackContainer
    {
        public Action OnDraw { get; }
        public Action<int> OnLeftWin { get; }
        public Action<int> OnRightWin { get; }

        public BattleResultCallbackContainer(Action onDraw, Action<int> onLeftWin, Action<int> onRightWin)
        {
            OnDraw = onDraw;
            OnLeftWin = onLeftWin;
            OnRightWin = onRightWin;
        }
    }
}