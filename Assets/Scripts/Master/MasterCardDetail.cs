using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("card_detail"), MessagePackObject(true)]
    public class MasterCardDetail 
    {
        public MasterCardDetail(
            int cardId,
            int detailId,
            int executeFrame)
        {
            CardId = cardId;
            DetailId = detailId;
            ExecuteFrame = executeFrame;
        }

        [PrimaryKey(0)]
        [SecondaryKey(0), NonUnique]
        public int CardId { get; }

        [PrimaryKey(1)]
        public int DetailId { get; }

        public int ExecuteFrame { get; }
    }
}