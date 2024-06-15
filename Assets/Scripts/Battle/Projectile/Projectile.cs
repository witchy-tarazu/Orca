using System.Collections.Generic;

namespace Orca
{
    public abstract class Projectile : IHitChecker, IUpdatable
    {
        public int Speed { get; private set; }

        public int TargetPos { get; private set; }
        public int CurrentPos { get; private set; }

        protected ProjectileData ProjectileData { get; private set; }

        protected ActorHealth OwnerHealth { get; private set; }

        public HashSet<ChildInfluencer> Children { get; set; } = new();

        protected BattleStage BattleStage { get; set; }

        public void Initialize(ProjectileData projectileData, ActorHealth ownerHealth, BattleStage battleStage)
        {
            Speed = projectileData.Speed;
            CurrentPos = projectileData.StartPos;
            TargetPos = CurrentPos + projectileData.Distance;
            ProjectileData = projectileData;
            OwnerHealth = ownerHealth;
            BattleStage = battleStage;
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