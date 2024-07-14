using MasterMemory;
using MessagePack;

namespace Orca
{
    [MemoryTable("piece"), MessagePackObject(true)]
    public class MasterPiece
    {
        public MasterPiece(int pieceId, string name, string description)
        {
            PieceId = pieceId;
            Name = name;
            Description = description;
        }

        [PrimaryKey]
        public int PieceId { get; }
        public string Name { get; }
        public string Description { get; }
    }
}