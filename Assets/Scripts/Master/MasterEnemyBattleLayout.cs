using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("enemy_battle_layout"), MessagePackObject(true)]
    public class MasterEnemyBattleLayout
    {
        public MasterEnemyBattleLayout(int layoutId, RoleType roleType, int positionIndex, int number)
        {
            LayoutId = layoutId;
            RoleType = roleType;
            PositionIndex = positionIndex;
            Number = number;
        }

        [PrimaryKey(0)]
        [SecondaryKey(0), NonUnique]
        public int LayoutId { get; }
        [PrimaryKey(1)]
        public RoleType RoleType { get; }
        [PrimaryKey(2)]
        public int PositionIndex { get; }
        public int Number { get; }
    }
}