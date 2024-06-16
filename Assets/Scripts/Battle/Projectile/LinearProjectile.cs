namespace Orca
{
    public class LinearProjectile : IProjectileStrategy
    {
        public void Update(
            Projectile projectile,
            ProjectileData data,
            BattleStage stage,
            int currentPos,
            int targetPos)
        {
            CheckData checkData = new(
                new() { stage.GetPanelPosition(currentPos) },
                data.OwnerHealth,
                InfluenceCheckSide.Opponent,
                InfluenceCheckTargetType.Position,
                InfluenceCheckRangeType.Single);
            data.Check(checkData, projectile);
        }
    }
}