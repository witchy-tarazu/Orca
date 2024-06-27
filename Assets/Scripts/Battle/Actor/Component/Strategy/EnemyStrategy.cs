using System;
using System.Collections.Generic;

namespace Orca
{
    public class EnemyStrategy : IActorStrategy
    {
        private Action<int> UseCardAction { get; set; }
        private Action<PanelPosition> MoveAction { get; set; }
        private Action<PanelPosition> JumpAction { get; set; }

        private BattleStage Stage { get; set; }
        private ActorHealth Health { get; set; }

        private List<MasterEnemyCommand> Commands { get; set; }
        private MasterEnemyCommand CurrentCommand { get; set; }

        private int CommandIndex { get; set; }
        private int Wait { get; set; }
        private bool IsLoop { get; set; }

        public EnemyStrategy(
            BattleStage stage,
            ActorHealth health,
            List<MasterEnemyCommand> commands,
            Action<int> useCardAction,
            Action<PanelPosition> moveAction,
            Action<PanelPosition> jumpAction)
        {
            Stage = stage;
            Health = health;
            Commands = commands;
            UseCardAction = useCardAction;
            MoveAction = moveAction;
            JumpAction = jumpAction;

            CommandIndex = 0;
            CurrentCommand = commands[CommandIndex];
            Wait = CurrentCommand.Wait;
            IsLoop = false;
        }

        // s“®‰Â”\‚Èó‘Ô‚Å‚Ì‚ÝUpdate‚ªŒÄ‚Î‚ê‚é
        public void Update()
        {
            if (Wait == 0)
            {
                Execute();
            }
        }

        private void Execute()
        {
            switch (CurrentCommand.Type)
            {
                case CommandType.Card:
                    UseCardAction.Invoke(CurrentCommand.Value);
                    break;
                case CommandType.Move:
                    Move();
                    break;
                case CommandType.MoveNearestEnemy:
                    MoveNearestEnemy();
                    break;
                case CommandType.Jump:
                    Jump();
                    break;
                case CommandType.JumpNearestEnemy:
                    JumpNearestEnemy();
                    break;
            }

            GoNext();
        }

        private void Move()
        {
            var currentPosition = Stage.GetPanel(Health).Position;
            int offset = (Health.Side == ActorSide.Left) ? CurrentCommand.Value : CurrentCommand.Value * -1;
            var nextPosition = new PanelPosition(currentPosition.PositionX + offset);
            MoveAction.Invoke(nextPosition);
        }

        private void MoveNearestEnemy()
        {
            var currentPosition = Stage.GetPanel(Health).Position;
            int offset = (Health.Side == ActorSide.Left) ? CurrentCommand.Value : CurrentCommand.Value * -1;
            var nearestEnemyPanel = Stage.GetNearestEnemyPanel(Health);
            var nextPosition = new PanelPosition(nearestEnemyPanel.Position.PositionX + offset);
            MoveAction.Invoke(nextPosition);
        }

        private void Jump()
        {
            var currentPosition = Stage.GetPanel(Health).Position;
            int offset = (Health.Side == ActorSide.Left) ? CurrentCommand.Value : CurrentCommand.Value * -1;
            var nextPosition = new PanelPosition(currentPosition.PositionX + offset);
            if (Stage.IsValidPos(nextPosition))
            {
                JumpAction.Invoke(nextPosition);
            }
        }

        private void JumpNearestEnemy()
        {
            var currentPosition = Stage.GetPanel(Health).Position;
            int offset = (Health.Side == ActorSide.Left) ? CurrentCommand.Value : CurrentCommand.Value * -1;
            var nearestEnemyPanel = Stage.GetNearestEnemyPanel(Health);
            var nextPosition = new PanelPosition(nearestEnemyPanel.Position.PositionX + offset);
            if (Stage.IsValidPos(nextPosition))
            {
                JumpAction.Invoke(nextPosition);
            }
        }

        private void GoNext()
        {
            do
            {
                CommandIndex++;
                if (CommandIndex >= Commands.Count)
                {
                    CommandIndex = 0;
                    IsLoop = true;
                }
                CurrentCommand = Commands[CommandIndex];
            } while (!CurrentCommand.IsOnce || !IsLoop);

            Wait = CurrentCommand.Wait;
        }
    }
}