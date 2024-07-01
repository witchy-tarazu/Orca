using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("piece"), MessagePackObject(true)]
    public class MasterPiece
    {
        public MasterPiece(int pieceId, int grade, int cardId)
        {
            PieceId = pieceId;
            Grade = grade;
            CardId = cardId;
        }

        [PrimaryKey(0), NonUnique]
        public int PieceId { get; }
        [PrimaryKey(1), NonUnique]
        public int Grade { get; }
        public int CardId { get; }
    }
}