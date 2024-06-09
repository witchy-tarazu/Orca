namespace Orca
{
    public abstract class Projectile
    {
        public int Speed { get; private set; }

        public int TargetPos { get; private set; }
        public int CurrentPos { get; private set; }

        protected ProjectileData ProjectileData { get; private set; }

        public Projectile(ProjectileData projectileData)
        {
            Speed = projectileData.Speed;
            CurrentPos = projectileData.StartPos;
            TargetPos = CurrentPos + projectileData.Distance;
            ProjectileData = projectileData;
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