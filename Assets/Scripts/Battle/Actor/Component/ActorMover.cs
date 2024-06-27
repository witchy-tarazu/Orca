namespace Orca
{
    public enum MoveType
    {
        Normal,
        Jump,
    }

    public class ActorMover : IActorAction
    {
        private BattleStage Stage { get; set; }
        private ActorHealth Health { get; set; }
        private int AbsoluteSpeed { get; set; }

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
            CurrentState = ActorComponentState.Active;
            MoveType = moveType;
            Target = target;

            switch (MoveType)
            {
                case MoveType.Normal:
                    executeNormal(target);
                    break;
                case MoveType.Jump:
                    executeJump(target);
                    break;
            }
        }

        private void executeNormal(PanelPosition target)
        {
            LinearPosition = Stage.GetLinearPositonCenter(Current);
            LinearTargetPosition = Stage.GetLinearPositonCenter(Target);

            CurrentState = ActorComponentState.Active;
            Speed = AbsoluteSpeed;

            if (LinearPosition > LinearTargetPosition)
            {
                Speed *= -1;
            }
        }

        private void executeJump(PanelPosition target)
        {
            LinearPosition = 0;
            LinearTargetPosition = Stage.WidthPerPanel;

            CurrentState = ActorComponentState.Active;
            Speed = AbsoluteSpeed;
        }

        public void Update()
        {
            if (CurrentState == ActorComponentState.Inactive) { return; }

            LinearPosition += Speed;

            if (Speed > 0)
            {
                if (LinearPosition > LinearTargetPosition)
                {
                    LinearPosition = LinearTargetPosition;
                }
            }
            else
            {
                if (LinearPosition < LinearTargetPosition)
                {
                    LinearPosition = LinearTargetPosition;
                }
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
            if (Stage.TryMove(nextPosition, Health, Cancel))
            {
                Current = nextPosition;
            }
        }

        private void Jump()
        {
            if (LinearPosition > Stage.WidthPerPanel / 2)
            {
                if (Stage.TryMove(Target, Health, Cancel))
                {
                    Current = Target;
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