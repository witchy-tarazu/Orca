using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("enemy"), MessagePackObject(true)]
    public class MasterEnemy
    {
        [PrimaryKey]
        public int Id { get; private set; }

        public int PatternId { get; private set; }

        public int MaxHp { get; private set; }

        public int Speed { get; private set; }
    }
}