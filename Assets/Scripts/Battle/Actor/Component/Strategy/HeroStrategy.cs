using System;

namespace Orca
{

    public class HeroStrategy : IActorStrategy
    {
        private BattleStage Stage { get; }
        private ActorHealth Health { get; }
        private BattleHeroData HeroData { get; }

        private InputContainer InputContainer { get; }

        private Action<MasterCard> UseCardAction { get; }
        private Action<PanelPosition> MoveAction { get; }


        private ActorCard Card { get; }


        public HeroStrategy(
            BattleStage stage,
            ActorHealth health,
            BattleHeroData heroData,
            Action<MasterCard> useCardAction,
            Action<PanelPosition> moveAction)

        {
            Stage = stage;
            Health = health;
            HeroData = heroData;
            InputContainer = heroData.InputContainer;
            UseCardAction = useCardAction;
            MoveAction = moveAction;

            Card = new();
        }

        public void Update()
        {
            // —Dæ“x‚ÍUŒ‚„ˆÚ“®
            var attackInput = InputContainer.Attack;
            if (attackInput != AttackCommand.None)
            {
                Attack(attackInput);
                return;
            }

            var directionInput = InputContainer.Direction;
            if (directionInput != DirectionCommand.None)
            {
                Move(directionInput);
            }
        }

        public void StartTurn()
        {
            Card.Set(HeroData.Cards);
        }

        private void Attack(AttackCommand command)
        {
            switch (command)
            {
                case AttackCommand.Attack:
                    UseCardAction.Invoke(HeroData.AttackMaster);
                    break;
                case AttackCommand.Card:
                    if (Card.HasCard())
                    {
                        UseCardAction.Invoke(Card.Use());
                    }
                    break;
            }
        }

        private void Move(DirectionCommand command)
        {
            var currentPosition = Stage.GetPanel(Health).Position;
            int offset = command switch
            {
                DirectionCommand.Left => (Health.Side == ActorSide.Left) ? -1 : 1,
                DirectionCommand.Right => (Health.Side == ActorSide.Left) ? 1 : -1,
                _ => 0,
            };
            var nextPosition = new PanelPosition(currentPosition.PositionX + offset);
            MoveAction.Invoke(nextPosition);
        }
    }
}