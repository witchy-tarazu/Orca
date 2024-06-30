using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("layout_lottery"), MessagePackObject(true)]
    public class MasterLayoutLottery
    {
        public MasterLayoutLottery(int stageId, int layoutId, int weight)
        {
            StageId = stageId;
            LayoutId = layoutId;
            Weight = weight;
        }

        [PrimaryKey(0), SecondaryKey(0), NonUnique]
        public int StageId { get; }
        [PrimaryKey(1), NonUnique]
        public int LayoutId { get; }
        public int Weight { get; }
    }
}