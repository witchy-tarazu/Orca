using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("card"), MessagePackObject(true)]
    public class MasterCard
    {
        public MasterCard(
            int cardId,
            int grade,
            int finishFrame)
        {
            CardId = cardId;
            Grade = grade;
            FinishFrame = finishFrame;
        }

        [PrimaryKey]
        public int CardId { get; }

        public int Grade { get; }

        public int FinishFrame { get; }
    }
}