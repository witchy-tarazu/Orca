using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public enum DirectionCommand
    {
        None,
        Up,
        Left,
        Right,
        Down,
    }

    public enum BattleCommand
    {
        None,
        Attack,
        Card,
        Custom,
        Pause,
    }

    public class BattleInputContainer
    {
        public BattleCommand BattleCommand { get; set; }
        public DirectionCommand DirectionCommand { get; set; }

        public BattleInputContainer()
        {
            Reset();
        }

        public void Reset()
        {
            BattleCommand = BattleCommand.None;
            DirectionCommand = DirectionCommand.None;
        }
    }
}