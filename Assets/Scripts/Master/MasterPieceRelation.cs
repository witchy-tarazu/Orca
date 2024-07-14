using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("piece_relation"), MessagePackObject(true)]
    public class MasterPieceRelation
    {
        public MasterPieceRelation(int pieceId, int grade, int cardId)
        {
            PieceId = pieceId;
            Grade = grade;
            CardId = cardId;
        }

        [PrimaryKey(0)]
        [SecondaryKey(0), NonUnique]
        public int PieceId { get; }
        [PrimaryKey(1)]
        public int Grade { get; }
        public int CardId { get; }
    }
}