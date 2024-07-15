using UnityEngine;

namespace Orca
{
    public enum MoveType
    {
        Normal,
        Jump,
    }

    public class ActorMover : IActorAction
    {
        private BattleStage Stage { get; }
        private ActorHealth Health { get; }
        private int AbsoluteSpeed { get; }

        public ActorComponentState CurrentState { get; private set; }

        private MoveType MoveType { get; set; }
        private PanelPosition Target { get; set; }
        private PanelPosition Current { get; set; }

        private int Speed { get; set; }

        private int LinearPosition { get; set; }
        private int LinearTargetPosition { get; set; }

        public ActorMover(BattleStage stage, ActorHealth health, int speed)
        {
            Stage = stage;
            Health = health;
            AbsoluteSpeed = speed;
            CurrentState = ActorComponentState.Inactive;
        }

        public void Execute(MoveType moveType, PanelPosition target)
        {
            MoveType = moveType;
            Target = target;

            switch (MoveType)
            {
                case MoveType.Normal:
                    ExecuteNormal();
                    break;
                case MoveType.Jump:
                    ExecuteJump();
                    break;
            }

            CurrentState = ActorComponentState.Active;
        }

        private void ExecuteNormal()
        {
            LinearPosition = Stage.GetLinearPositonCenter(Current);
            LinearTargetPosition = Stage.GetLinearPositonCenter(Target);

            Speed = AbsoluteSpeed;

            if (LinearPosition > LinearTargetPosition)
            {
                Speed *= -1;
            }
        }

        private void ExecuteJump()
        {
            LinearPosition = 0;
            LinearTargetPosition = Stage.WidthPerPanel;

            Speed = AbsoluteSpeed;
        }

        public void Update()
        {
            if (CurrentState == ActorComponentState.Inactive) { return; }

            LinearPosition += Speed;

            if (Speed > 0)
            {
                Mathf.Min(LinearPosition, LinearTargetPosition);
            }
            else
            {
                Mathf.Max(LinearPosition, LinearTargetPosition);
            }

            switch (MoveType)
            {
                case MoveType.Normal:
                    Move();
                    break;
                case MoveType.Jump:
                    Jump();
                    break;
            }
        }

        private void Move()
        {
            var nextPosition = Stage.GetPanelPosition(LinearPosition);
            if (Stage.TryMove(nextPosition, Health))
            {
                Current = nextPosition;
            }
            else
            {
                Cancel();
            }
        }

        private void Jump()
        {
            if (LinearPosition > LinearTargetPosition / 2)
            {
                if (Stage.TryMove(Target, Health))
                {
                    Current = Target;
                }
                else
                {
                    Cancel();
                }
            }
        }

        public void LateUpdate()
        {
            if (LinearPosition == LinearTargetPosition)
            {
                Cancel();
            }
        }

        public void Cancel()
        {
            CurrentState = ActorComponentState.Inactive;
            Target = Current;
        }
    }
}