using MasterMemory;
using MessagePack;

namespace Orca
{
    public enum PanelType
    {
        Normal,
        Hall,
    }

    [MemoryTable("stage"), MessagePackObject(true)]
    public class MasterStage
    {
        public MasterStage(int id, int panelIndex, PanelType panelType)
        {
            Id = id;
            PanelIndex = panelIndex;
            PanelType = panelType;
        }

        [PrimaryKey(0), SecondaryKey(0), NonUnique]
        public int Id { get; }

        [PrimaryKey(1), NonUnique]
        public int PanelIndex { get; }

        public PanelType PanelType { get; }
    }
}