using MasterMemory;
using MessagePack;

namespace Orca
{
    public enum RoleType
    {
        Player,
        Defender,
        Front,
        Thrower,
        Shooter,
    }

    [MemoryTable("enemy"), MessagePackObject(true)]
    public class MasterEnemy
    {
        public MasterEnemy(int id, RoleType roleType, int level, int patternId, int maxHp, int speed)
        {
            Id = id;
            RoleType = roleType;
            Level = level;
            PatternId = patternId;
            MaxHp = maxHp;
            Speed = speed;
        }

        [PrimaryKey]
        public int Id { get; }

        [SecondaryKey(0, 0), NonUnique]
        public RoleType RoleType { get; }


        [SecondaryKey(0, 1), NonUnique]
        public int Level { get; }

        public int PatternId { get; }

        public int MaxHp { get; }

        public int Speed { get; }
    }
}