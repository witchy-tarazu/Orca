namespace Orca
{
    public class ParabolaProjectile : Projectile
    {
        public override void Update()
        {
            base.Update();

            if (CurrentPos == TargetPos)
            {
                CheckData checkData = new(CurrentPos, CheckSide.Whole, CheckRange.Position, CheckType.Panel);
                ProjectileData.Check(checkData, this);
            }
        }
    }
}