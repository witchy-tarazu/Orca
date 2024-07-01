using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("card"), MessagePackObject(true)]
    public class MasterCard
    {
        public MasterCard(
            int cardId,
            int finishFrame)
        {
            CardId = cardId;
            FinishFrame = finishFrame;
        }

        [PrimaryKey]
        public int CardId { get; }

        public int FinishFrame { get; }
    }
}