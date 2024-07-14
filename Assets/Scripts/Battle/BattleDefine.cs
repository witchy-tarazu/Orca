using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public static class BattleDefine
    {
        public const int PoisonSlipDamage = 10;
        public const int RegenerationValue = 10;
        public const int DazzleDamage = 10;

        public const int WidthPerPanel = 100;

        public const int MaxCustomPieceCount = 10;
        public const int DefaultCustomDrawCount = 5;
    }

    public enum ControllerState
    {
        Inactive,
        Pause,
        Active,
    }
}