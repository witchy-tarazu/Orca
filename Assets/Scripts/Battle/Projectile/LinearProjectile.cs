namespace Orca
{
    public class LinearProjectile : Projectile
    {
        public override void Update()
        {
            base.Update();

            CheckData checkData = new(
                new() { BattleStage.GetPanelPosition(CurrentPos) },
                OwnerHealth,
                InfluenceCheckSide.Opponent,
                InfluenceCheckTargetType.Position,
                InfluenceCheckRangeType.Single);
            ProjectileData.Check(checkData, this);
        }
    }
}