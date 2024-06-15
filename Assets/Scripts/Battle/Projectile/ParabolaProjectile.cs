namespace Orca
{
    public class ParabolaProjectile : Projectile
    {
        public override void Update()
        {
            base.Update();

            if (CurrentPos == TargetPos)
            {
                CheckData checkData = new(
                    new() { BattleStage.GetPanelPosition(CurrentPos) },
                    OwnerHealth,
                    InfluenceCheckSide.Whole,
                    InfluenceCheckTargetType.Position,
                    InfluenceCheckRangeType.Panel);
                ProjectileData.Check(checkData, this);
            }
        }
    }
}