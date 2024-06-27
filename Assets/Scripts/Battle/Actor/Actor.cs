using System;
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

        private Action<Actor> OnDeadCallback { get; set; }

        private MemoryDatabase MasterDatabase { get; set; }

        public Actor(MemoryDatabase masterDatabase, BattleStage stage)
        {
            MasterDatabase = masterDatabase;
            Stage = stage;
        }

        public void SetupHero()
        {

        }

        public void SetupEnemy(
            ActorSide side,
            int enemyId,
            InfluencerFactory influencerFactory,
            ProjectileFactory projectileFactory,
            Action<IUpdatable> registerForSystem,
            Action<IUpdatable> releaseForSystem)
        {
            var enemyMaster = MasterDatabase.MasterEnemyTable.FindById(enemyId);
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
        }

        public void Update()
        {
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
            if (!Health.IsAlive)
            {
                OnDeadCallback.Invoke(this);
            }
        }
    }
}