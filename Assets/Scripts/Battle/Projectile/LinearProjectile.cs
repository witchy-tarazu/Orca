namespace Orca
{
    public class LinearProjectile : Projectile
    {
        public LinearProjectile(ProjectileData data) : base(data) { }

        public override void Update()
        {
            base.Update();

            ProjectileData.Check(CurrentPos);
        }
    }
}