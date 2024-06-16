namespace Orca
{
    public interface IProjectileStrategy
    {
        void Update(
            Projectile projectile,
            ProjectileData data,
            BattleStage stage,
            int currentPos,
            int targetPos);
    }
}