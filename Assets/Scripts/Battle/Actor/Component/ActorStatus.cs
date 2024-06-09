using System;
using System.Collections.Generic;

namespace Orca
{
    public class ActorStatus
    {
        private HashSet<BattleState> status = new();
        private HashSet<BattleStack> stacks = new();

        public void ApplyToAllStatus(Action<BattleState> action)
        {
            foreach (BattleState state in status) { action(state); }
        }

        public void ApplyToAllStacks(Action<BattleStack> action)
        {
            foreach (BattleStack stack in stacks) { action(stack); }
        }
    }
}