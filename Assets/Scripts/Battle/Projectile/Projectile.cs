using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class Projectile : IHitChecker, IUpdatable
    {
        public int Speed { get; private set; }

        public int TargetPos { get; private set; }
        public int CurrentPos { get; private set; }

        private ProjectileData ProjectileData { get; set; }

        public HashSet<ChildInfluencer> Children { get; set; } = new();

        private BattleStage BattleStage { get; set; }

        private IProjectileStrategy Strategy { get; set; }

        private LinearProjectileStrategy LinearProjectile { get; set; }
        private ParabolaProjectileStrategy ParabolaProjectile { get; set; }

        public ActorHealth OwnerHealth => ProjectileData.OwnerHealth;

        public void Setup(ProjectileData projectileData, BattleStage battleStage)
        {
            Speed = projectileData.Master.Speed;
            CurrentPos = projectileData.StartPos;
            TargetPos = CurrentPos + projectileData.Master.Distance;
            ProjectileData = projectileData;
            BattleStage = battleStage;

            switch (ProjectileData.Master.ProjectileType)
            {
                case ProjectileType.Linear:
                    Strategy = (LinearProjectile ??= new LinearProjectileStrategy());
                    break;
                case ProjectileType.Parabola:
                    Strategy = (ParabolaProjectile ??= new ParabolaProjectileStrategy());
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
            CurrentPos = Mathf.Min(CurrentPos, TargetPos);

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
    }
}