namespace Orca
{
    public class ParabolaProjectileStrategy : IProjectileStrategy
    {
        public void Update(
            Projectile projectile,
            ProjectileData data,
            BattleStage stage,
            int currentPos,
            int targetPos)
        {
            if (currentPos == targetPos)
            {
                CheckData checkData = new(
                    new() { stage.GetPanelPosition(currentPos) },
                    data.OwnerHealth,
                    InfluenceCheckSide.Whole,
                    InfluenceCheckTargetType.Position,
                    InfluenceCheckRangeType.Panel);
                data.Check(checkData, projectile);
            }
        }
    }
}