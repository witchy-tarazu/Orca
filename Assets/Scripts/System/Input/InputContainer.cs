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

    public enum AttackCommand
    {
        None,
        Attack,
        Card,
    }

    public class InputContainer
    {
        public AttackCommand Attack { get; set; }
        public DirectionCommand Direction { get; set; }

        public InputContainer()
        {
            Reset();
        }

        public void Reset()
        {
            Attack = AttackCommand.None;
            Direction = DirectionCommand.None;
        }
    }
}