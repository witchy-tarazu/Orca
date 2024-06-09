using Unity.VisualScripting;

namespace Orca
{
    public class ParabolaProjectile : Projectile
    {
        public ParabolaProjectile(ProjectileData data) : base(data) { }

        public override void Update()
        {
            base.Update();

            if (CurrentPos == TargetPos)
            {
                ProjectileData.Check(CurrentPos);
            }
        }
    }
}