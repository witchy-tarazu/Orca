using System;
using System.Collections.Generic;
using System.Linq;

namespace Orca
{
    public enum ActorSide
    {
        Left,
        Right,
    }
    public enum ActorComponentState
    {
        Inactive,
        Active,
    }

    public class Actor : IUpdatable
    {
        private ActorAttacker Attacker { get; set; }
        private ActorMover Mover { get; set; }
        private ActorHealth Health { get; set; }
        private IActorStrategy Strategy { get; set; }

        private BattleStage Stage { get; set; }

        private Action OnDeadCallback { get; set; }

        private MemoryDatabase MasterDatabase { get; set; }

        public Actor(MemoryDatabase masterDatabase, BattleStage stage)
        {
            MasterDatabase = masterDatabase;
            Stage = stage;
        }

        public void SetupHero(
            ActorSide side,
            ActorLayoutData layoutData,
            InfluencerFactory influencerFactory,
            ProjectileFactory projectileFactory,
            Action<IUpdatable> registerForSystem,
            Action<IUpdatable> releaseForSystem,
            Action onDeadCallback)
        {
            var heroData = layoutData.HeroData;
            Health = new(side, heroData.Hp, heroData.MaxHp);
            Attacker = new(influencerFactory, projectileFactory, registerForSystem, releaseForSystem, Health);
            Mover = new(Stage, Health, heroData.Speed);
            Strategy = new HeroStrategy(Stage, Health, heroData,
                Attacker.Execute,
                position => Mover.Execute(MoveType.Normal, position));
            OnDeadCallback = onDeadCallback;
            Stage.AddHealth(heroData.StartPosition, Health);
        }

        public void SetupEnemy(
            ActorSide side,
            ActorPositionData positionData,
            InfluencerFactory influencerFactory,
            ProjectileFactory projectileFactory,
            Action<IUpdatable> registerForSystem,
            Action<IUpdatable> releaseForSystem,
            Action onDeadCallback)
        {
            var enemyMaster = positionData.Enemy;
            Health = new(side, enemyMaster.MaxHp);
            Attacker = new(influencerFactory, projectileFactory, registerForSystem, releaseForSystem, Health);
            Mover = new(Stage, Health, enemyMaster.Speed);
            var commands = MasterDatabase.MasterEnemyCommandTable
                .FindByPatternId(enemyMaster.PatternId)
                .OrderBy(x => x.Index).ToList();
            Strategy = new EnemyStrategy(Stage, Health, commands,
                cardId => Attacker.Execute(MasterDatabase.MasterCardTable.FindByCardId(cardId)),
                position => Mover.Execute(MoveType.Normal, position),
                position => Mover.Execute(MoveType.Jump, position));
            OnDeadCallback = onDeadCallback;
            Stage.AddHealth(positionData.Position, Health);
        }

        public void Update()
        {
            Health.Update();

            if (Health.IsDisableAction)
            {
                return;
            }

            if (Attacker.CurrentState == ActorComponentState.Inactive
                && Mover.CurrentState == ActorComponentState.Inactive)
            {
                // アクティブなコンポーネントがない場合はStrategyを動かす
                Strategy.Update();
            }

            Attacker.Update();
            Mover.Update();
        }

        public void LateUpdate()
        {
            if (Health.IsDisableAction)
            {
                Attacker.Cancel();
                Mover.Cancel();
            }

            if (!Health.IsAlive)
            {
                OnDeadCallback.Invoke();
                return;
            }

            Health.LateUpdate();
        }

        public void StartTurn(List<MasterCard> cards)
        {
            if (Strategy is not HeroStrategy)
            {
                return;
            }

            var heroStrategy = Strategy as HeroStrategy;
            heroStrategy.StartTurn(cards);
        }

        public bool IsHero(ActorSide side)
        {
            return Health.Side == side && Strategy is HeroStrategy;
        }

        public int GetHp() => Health.GetHp();
    }
}