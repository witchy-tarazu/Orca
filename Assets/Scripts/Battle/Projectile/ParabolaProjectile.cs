using Unity.VisualScripting;

namespace Orca
{
    public class ParabolaProjectile : Projectile
    {
        public override void Update()
        {
            base.Update();

            if (CurrentPos == TargetPos)
            {
                CheckData checkData = new(CurrentPos, ProjectileData.Side, CheckType.Position);
                ProjectileData.Check(checkData, this);
            }
        }
    }
}