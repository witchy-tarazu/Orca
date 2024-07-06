using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("card"), MessagePackObject(true)]
    public class MasterCard
    {
        public MasterCard(
            int cardId,
            int finishFrame,
            string name,
            string description)
        {
            CardId = cardId;
            FinishFrame = finishFrame;
            Name = name;
            Description = description;
        }

        [PrimaryKey]
        public int CardId { get; }

        public int FinishFrame { get; }

        public string Name { get; }
        public string Description { get; }
    }
}