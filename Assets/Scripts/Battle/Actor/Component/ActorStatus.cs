using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Orca
{
    public class ActorStatus
    {
        private HashSet<BattleState> Status { get; set; } = new();
        private HashSet<BattleStack> Stacks { get; set; } = new();


        public ActorStatus(Action<ActorState> abnormalApplyAction)
        {
            Status.Add(new(ActorState.Poison, abnormalApplyAction));
            Status.Add(new(ActorState.Darkness, abnormalApplyAction));
            Status.Add(new(ActorState.Invincible, abnormalApplyAction));
            Status.Add(new(ActorState.Dazzle, abnormalApplyAction));
            Status.Add(new(ActorState.Stan, abnormalApplyAction));
            Status.Add(new(ActorState.Regeneration, abnormalApplyAction));

            Stacks.Add(new(ActorState.AttackBuff));
            Stacks.Add(new(ActorState.DefenceBuff));
            Stacks.Add(new(ActorState.Barrier));
            Stacks.Add(new(ActorState.Charge));
            Stacks.Add(new(ActorState.Critical));
            Stacks.Add(new(ActorState.Drain));
        }

        public void Update()
        {
            foreach (var state in Status)
            {
                state.Update();
            }
        }

        public void LateUpdate()
        {
            foreach (var state in Status)
            {
                state.Consume(1);
            }
        }

        public void ApplyToAllStatus(Action<BattleState> action)
        {
            foreach (BattleState state in Status) { action.Invoke(state); }
        }

        public void ApplyToAllStacks(Action<BattleStack> action)
        {
            foreach (BattleStack stack in Stacks) { action.Invoke(stack); }
        }

        public bool IsState(ActorState state) =>
            Status.Any(x => x.State == state && x.IsEnable);

        public void MakeState(ActorState state, int duration) =>
            Status.Where(x => x.State == state).First().AddFrame(duration);

        public void RemoveState(ActorState state) =>
            Status.Where(x => x.State == state).First().ResetRemainFrame();

        public bool HasStack(ActorState state) =>
            Stacks.Any(x => x.State == state && x.IsEnable);

        public int GetStackValue(ActorState state) =>
            Stacks.Where(x => x.State == state).First().StackValue;

        public void ConsumeStack(ActorState state, int value)
        {
            var targetStack = Stacks.Where(stack => stack.State == state).First();
            targetStack.Consume(value);
        }

        public void AddStack(ActorState state, int value)
        {
            var targetStack = Stacks.Where(stack => stack.State == state).First();
            targetStack.Stack(value);
        }

        public void RemoveStack(ActorState state)
        {
            var targetStack = Stacks.Where(stack => stack.State == state).First();
            targetStack.Reset();
        }
    }
}