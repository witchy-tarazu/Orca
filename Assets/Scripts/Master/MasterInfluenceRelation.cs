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

        /// <summary>親効果ID</summary>
        [PrimaryKey(0), NonUnique]
        public int ParentId { get; }

        /// <summary>子効果の発動条件</summary>
        public ChildTriggerCondition TriggerCondition { get; }

        [PrimaryKey(1)]
        /// <summary>子効果のID</summary>
        public int ChildId { get; }

    }
}