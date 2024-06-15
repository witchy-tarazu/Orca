namespace Orca
{
    public class LinearProjectile : Projectile
    {
        public override void Update()
        {
            base.Update();

            CheckData checkData = new(CurrentPos, CheckSide.Opponent, CheckRange.Position, CheckType.Single);
            ProjectileData.Check(checkData, this);
        }
    }
}