using System;

namespace Orca
{

    public class HeroStrategy : IActorStrategy
    {
        private BattleStage Stage { get; }
        private ActorHealth Health { get; }
        private BattleHeroData HeroData { get; }

        private BattleInputContainer InputContainer { get; }

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
            var attackInput = InputContainer.BattleCommand;
            if (attackInput != BattleCommand.None)
            {
                Attack(attackInput);
                return;
            }

            var directionInput = InputContainer.DirectionCommand;
            if (directionInput != DirectionCommand.None)
            {
                Move(directionInput);
            }
        }

        public void StartTurn()
        {
            Card.Set(HeroData.Cards);
        }

        private void Attack(BattleCommand command)
        {
            switch (command)
            {
                case BattleCommand.Attack:
                    UseCardAction.Invoke(HeroData.AttackMaster);
                    break;
                case BattleCommand.Card:
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