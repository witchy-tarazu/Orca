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
            int finishFrame,
            int cancellableFrame)
        {
            CardId = cardId;
            Grade = grade;
            FinishFrame = finishFrame;
            CancellableFrame = cancellableFrame;
        }

        [PrimaryKey]
        public int CardId { get; }

        public int Grade { get; }

        public int FinishFrame { get; }

        public int CancellableFrame { get; }
    }
}