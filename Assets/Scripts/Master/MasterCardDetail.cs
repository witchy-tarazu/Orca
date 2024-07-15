using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("card_detail"), MessagePackObject(true)]
    public class MasterCardDetail 
    {
        public MasterCardDetail(
            int cardId,
            int detailId)
        {
            CardId = cardId;
            DetailId = detailId;
        }

        [PrimaryKey(0)]
        [SecondaryKey(0), NonUnique]
        public int CardId { get; }

        [PrimaryKey(1)]
        public int DetailId { get; }
    }
}