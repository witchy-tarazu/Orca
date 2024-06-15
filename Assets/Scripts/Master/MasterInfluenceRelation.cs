using MasterMemory;
using MessagePack;

namespace Orca
{
    public enum ChildTriggerCondition
    {
        None = 0,
        Hit,
        NoHit,
        Damage,
        NoDamage,
    }

    [MemoryTable("influence_relation"), MessagePackObject(true)]
    public class MasterInfluenceRelation
    {
        public MasterInfluenceRelation(
            int parentId,
            ChildTriggerCondition triggerCondition,
            int childId)
        {
            ParentId = parentId;
            TriggerCondition = triggerCondition;
            ChildId = childId;
        }

        /// <summary>eŒø‰ÊID</summary>
        [PrimaryKey(0), NonUnique]
        public int ParentId { get; }

        /// <summary>qŒø‰Ê‚Ì”­“®ğŒ</summary>
        public ChildTriggerCondition TriggerCondition { get; }

        [PrimaryKey(1)]
        /// <summary>qŒø‰Ê‚ÌID</summary>
        public int ChildId { get; }

    }
}