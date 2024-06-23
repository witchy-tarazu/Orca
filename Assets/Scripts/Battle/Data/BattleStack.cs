using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class BattleStack
    {
        public ActorState State { get; private set; }
        public int StackValue { get; private set; }

        public bool IsEnable => StackValue > 0;

        public BattleStack(ActorState state)
        {
            State = state;
            Reset();
        }

        public void Stack(int value)
        {
            StackValue += value;
        }

        public void Consume(int value)
        {
            StackValue -= value;

            if (StackValue < 0
                && State != ActorState.AttackBuff
                && State != ActorState.DefenceBuff)
            {
                Reset();
            }
        }

        public void Reset()
        {
            StackValue = 0;
        }
    }
}