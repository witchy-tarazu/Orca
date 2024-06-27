using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("enemy"), MessagePackObject(true)]
    public class MasterEnemy
    {
        public MasterEnemy(int id, int patternId, int maxHp, int speed)
        {
            Id = id;
            PatternId = patternId;
            MaxHp = maxHp;
            Speed = speed;
        }

        [PrimaryKey]
        public int Id { get;}

        public int PatternId { get;  }

        public int MaxHp { get; }

        public int Speed { get; }
    }
}