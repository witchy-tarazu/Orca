using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("boss_battle_layout"), MessagePackObject(true)]
    public class MasterBossBattleLayout
    {
        public MasterBossBattleLayout(int layoutId, int enemyId, int positionIndex)
        {
            LayoutId = layoutId;
            EnemyId = enemyId;
            PositionIndex = positionIndex;
        }

        [PrimaryKey(0)]
        [SecondaryKey(0), NonUnique]
        public int LayoutId { get; }
        [PrimaryKey(1)]
        public int EnemyId { get; }
        public int PositionIndex { get; }
    }
}