using System.Collections.Generic;

namespace Orca
{
    public class BattleSystem
    {
        private List<IUpdatable> PlayerList { get; set; } = new();
        private List<IUpdatable> EnemyList { get; set; } = new();
        private List<IUpdatable> PlayerAutonomyList { get; set; } = new();
        private List<IUpdatable> EnemyAutonomyList { get; set; } = new();
        private BattleStage Stage { get; set; }

        private InfluencerFactory InfluencerFactory { get; set; }
        private ProjectileFactory ProjectileFactory { get; set; }

        private HashSet<IUpdatable> ReservedUpdatables { get; set; } = new();
        private HashSet<IUpdatable> ActiveUpdatables { get; set; } = new();
        private HashSet<IUpdatable> FinishedUpdatables { get; set; } = new();

        private HitProcessor HitProcessor { get; set; }

        public void Setup(MemoryDatabase memoryDatabase)
        {
            InfluencerFactory = new(Stage, memoryDatabase, Check, ProcessHit);
            ProjectileFactory = new(Stage, memoryDatabase, Check, ProcessHit);

            HitProcessor = new(CreateInfluencerForChild, CreateProjectileForChild);
        }

        public void Update()
        {
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
    }
}