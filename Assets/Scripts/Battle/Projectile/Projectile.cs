using System.Collections.Generic;

namespace Orca
{
    public class Projectile : IHitChecker, IUpdatable
    {
        public int Speed { get; private set; }

        public int TargetPos { get; private set; }
        public int CurrentPos { get; private set; }

        private ProjectileData ProjectileData { get; set; }

        public int Grade { get; private set; }

        public HashSet<ChildInfluencer> Children { get; set; } = new();

        private BattleStage BattleStage { get; set; }

        private IProjectileStrategy Strategy { get; set; }

        private LinearProjectile LinearProjectile { get; set; }
        private ParabolaProjectile ParabolaProjectile { get; set; }

        public ActorHealth OwnerHealth => ProjectileData.OwnerHealth;

        public void Setup(ProjectileData projectileData, int grade, BattleStage battleStage)
        {
            Speed = projectileData.Master.Speed;
            CurrentPos = projectileData.StartPos;
            TargetPos = CurrentPos + projectileData.Master.Distance;
            ProjectileData = projectileData;
            Grade = grade;
            BattleStage = battleStage;

            switch (ProjectileData.Master.ProjectileType)
            {
                case ProjectileType.Linear:
                    Strategy = (LinearProjectile ??= new LinearProjectile());
                    break;
                case ProjectileType.Parabola:
                    Strategy = (ParabolaProjectile ??= new ParabolaProjectile());
                    break;
            }

            Children.Clear();
        }

        public void AppendChild(ChildInfluencer child)
        {
            Children.Add(child);
        }

        public virtual void Update()
        {
            CurrentPos += Speed;
            if (CurrentPos > TargetPos)
            {
                CurrentPos = TargetPos;
            }

            Strategy.Update(this, ProjectileData, BattleStage, CurrentPos, TargetPos);
        }

        public void Hit(HitData hitData)
        {
            ProjectileData.Hit(hitData);
            ProjectileData.Release();
        }

        public void LateUpdate()
        {
            if (TargetPos == CurrentPos)
            {
                ProjectileData.Release();
            }
        }

        public MasterProjectile GetMaster()
        {
            return ProjectileData.Master;
        }
    }
}