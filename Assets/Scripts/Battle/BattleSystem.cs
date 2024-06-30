using System.Collections.Generic;
using System.Linq;

namespace Orca
{
    public enum BattleGameState
    {
        Active,
        Pause,
        End,
    }

    public class BattleSystem
    {
        private BattleStage Stage { get; set; }

        private InfluencerFactory InfluencerFactory { get; set; }
        private ProjectileFactory ProjectileFactory { get; set; }

        private HashSet<IUpdatable> ReservedUpdatables { get; set; } = new();
        private HashSet<IUpdatable> ActiveUpdatables { get; set; } = new();
        private HashSet<IUpdatable> FinishedUpdatables { get; set; } = new();

        private HashSet<Actor> HeroActors { get; set; } = new();

        private HitProcessor HitProcessor { get; set; }

        private BattleGameState BattleGameState { get; set; }

        private int LeftSideAliveness { get; set; }
        private int RightSideAliveness { get; set; }

        private BattleResultCallbackContainer ResultCallbackContainer { get; set; }

        public BattleSystem(
            MemoryDatabase memoryDatabase,
            BattleStage stage,
            ActorLayoutData leftLayout,
            ActorLayoutData rightLayout,
            BattleResultCallbackContainer resultCallbackContainer)
        {
            InfluencerFactory = new(Stage, memoryDatabase, Check, ProcessHit);
            ProjectileFactory = new(Stage, memoryDatabase, Check, ProcessHit);

            HitProcessor = new(CreateInfluencerForChild, CreateProjectileForChild);

            Stage = stage;
            LeftSideAliveness = 0;
            RightSideAliveness = 0;

            for (int i = 0; i < leftLayout.ActorDataList.Count; i++)
            {
                var actorData = leftLayout.ActorDataList[i];
                Actor enemy = new(memoryDatabase, Stage);
                enemy.SetupEnemy(
                    ActorSide.Left, actorData,
                    InfluencerFactory, ProjectileFactory,
                    Register, Release,
                    () =>
                    {
                        LeftSideAliveness--;
                        Release(enemy);
                    });
                ActiveUpdatables.Add(enemy);
                LeftSideAliveness++;
            }
            if (leftLayout.HeroData != null)
            {
                Actor hero = new(memoryDatabase, Stage);
                hero.SetupHero(
                    ActorSide.Left, leftLayout,
                    InfluencerFactory, ProjectileFactory,
                    Register, Release,
                    () =>
                    {
                        LeftSideAliveness--;
                        Release(hero);
                        HeroActors.Remove(hero);
                    });
                ActiveUpdatables.Add(hero);
                HeroActors.Add(hero);
                LeftSideAliveness++;
            }

            for (int i = 0; i < rightLayout.ActorDataList.Count; i++)
            {
                var actorData = rightLayout.ActorDataList[i];
                Actor enemy = new(memoryDatabase, Stage);
                enemy.SetupEnemy(
                    ActorSide.Right, actorData,
                    InfluencerFactory, ProjectileFactory,
                    Register, Release,
                    () =>
                    {
                        RightSideAliveness--;
                        Release(enemy);
                    });
                ActiveUpdatables.Add(enemy);
                RightSideAliveness++;
            }
            if (rightLayout.HeroData != null)
            {
                Actor hero = new(memoryDatabase, Stage);
                hero.SetupHero(
                    ActorSide.Right, rightLayout,
                    InfluencerFactory, ProjectileFactory,
                    Register, Release,
                    () =>
                    {
                        RightSideAliveness--;
                        Release(hero);
                        HeroActors.Remove(hero);
                    });
                ActiveUpdatables.Add(hero);
                HeroActors.Add(hero);
                RightSideAliveness++;
            }

            BattleGameState = BattleGameState.Pause;
            ResultCallbackContainer = resultCallbackContainer;
        }

        public void Update()
        {
            if (BattleGameState != BattleGameState.Active)
            {
                return;
            }

            foreach (var updatable in ReservedUpdatables)
            {
                ActiveUpdatables.Add(updatable);
            }
            ReservedUpdatables.Clear();

            foreach (var updatable in ActiveUpdatables)
            {
                updatable.Update();
            }

            foreach (var updatable in FinishedUpdatables)
            {
                ActiveUpdatables.Remove(updatable);
            }
            FinishedUpdatables.Clear();

            JudgeEndGame();
        }

        private void JudgeEndGame()
        {
            if (LeftSideAliveness != 0 && RightSideAliveness != 0)
            {
                // ƒoƒgƒ‹Œp‘±
                return;
            }

            BattleGameState = BattleGameState.End;

            if (LeftSideAliveness == 0 && RightSideAliveness == 0)
            {
                // ˆø‚«•ª‚¯
                ResultCallbackContainer.OnDraw.Invoke();
                return;
            }

            if (LeftSideAliveness == 0)
            {
                // ‰E‘¤Ÿ—˜
                var hero = HeroActors.FirstOrDefault(x => x.IsHero(ActorSide.Right));
                ResultCallbackContainer.OnRightWin.Invoke(hero.GetHp());
                return;
            }

            if (RightSideAliveness == 0)
            {
                // ¶‘¤Ÿ—˜
                var hero = HeroActors.FirstOrDefault(x => x.IsHero(ActorSide.Left));
                ResultCallbackContainer.OnLeftWin.Invoke(hero.GetHp());
                return;
            }
        }

        private void Check(CheckData check, IHitChecker hit)
        {
            switch (check.CheckType)
            {
                case InfluenceCheckTargetType.Self:
                    {
                        var panel = Stage.GetPanel(check.OwnerHealth);
                        HitData hitData = new(panel, new() { check.OwnerHealth });
                        hit.Hit(hitData);
                    }
                    break;
                case InfluenceCheckTargetType.Whole:
                    {
                        var panels = Stage.GetAllPanelHasActor();
                        foreach (var panel in panels)
                        {
                            var targetList = panel.ListupHealth(check);
                            if (targetList.Count == 0) { continue; }
                            HitData hitData = new(panel, panel.ListupHealth(check));
                            hit.Hit(hitData);
                        }
                    }
                    break;
                case InfluenceCheckTargetType.Position:
                    CheckByPosition(check, hit);
                    break;
            }
        }

        private void CheckByPosition(CheckData check, IHitChecker hit)
        {
            switch (check.CheckTargetType)
            {
                case InfluenceCheckRangeType.Single:
                    {
                        var panel = Stage.GetNearestPanel(check);
                        HitData hitData = new(panel, panel.ListupHealth(check));
                        hit.Hit(hitData);
                    }
                    return;
                case InfluenceCheckRangeType.Panel:
                    check.ApplyToPositions(
                    position =>
                    {
                        var panel = Stage.GetPanel(position);
                        var targetList = panel.ListupHealth(check);
                        HitData hitData = new(panel, targetList);
                        hit.Hit(hitData);
                    });
                    return;
            }
        }

        private void ProcessHit(
            HitData hitData,
            Influencer influencer)
        {
            HitProcessor.Process(hitData, influencer);
        }

        private void ProcessHit(
            HitData hitData,
            Projectile projectile)
        {
            HitProcessor.Process(hitData, projectile);
        }

        private void CreateInfluencerForChild(
            int influeceId,
            int grade,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition)
        {
            var influencer = InfluencerFactory.CreateInfluencer(influeceId, grade, ownerHealth, ownerPosition, Release);
            Register(influencer);
        }

        private void CreateProjectileForChild(
            int projectileId,
            int grade,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition)
        {
            var projectile = ProjectileFactory.CreateProjectile(projectileId, grade, ownerHealth, ownerPosition, Release);
            Register(projectile);
        }

        private void Register(IUpdatable updatable)
        {
            ReservedUpdatables.Add(updatable);
        }

        private void Release(IUpdatable updatable)
        {
            FinishedUpdatables.Add(updatable);
        }

        private void Pause()
        {
            BattleGameState = BattleGameState.Pause;
        }

        private void StartTurn(ActorSide side, List<MasterCard> cards)
        {
            BattleGameState = BattleGameState.Active;
            foreach (var hero in HeroActors)
            {
                hero.StartTurn();
            }
        }
    }
}