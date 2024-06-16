using MasterMemory;
using MessagePack;

namespace Orca
{
    public enum ProjectileType
    {
        Linear,
        Parabola,
    }

    public enum ProjetileStartType
    {
        Center,
        Edge,
    }

    [MemoryTable("projectile"), MessagePackObject(true)]
    public class MasterProjectile
    {
        [PrimaryKey]
        public int ProjectileId { get; }

        public ProjectileType ProjectileType { get; }

        public ProjetileStartType StartType { get; }

        public int Speed { get; }

        public int Distance { get; }
    }
}