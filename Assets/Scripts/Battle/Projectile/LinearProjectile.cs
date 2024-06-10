namespace Orca
{
    public class LinearProjectile : Projectile
    {
        public override void Update()
        {
            base.Update();

            CheckData checkData = new(CurrentPos, ProjectileData.Side, CheckType.Position);
            ProjectileData.Check(checkData, this);
        }
    }
}