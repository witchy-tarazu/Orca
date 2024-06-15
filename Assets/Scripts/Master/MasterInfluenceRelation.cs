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

        /// <summary>�e����ID</summary>
        [PrimaryKey(0), NonUnique]
        public int ParentId { get; }

        /// <summary>�q���ʂ̔�������</summary>
        public ChildTriggerCondition TriggerCondition { get; }

        [PrimaryKey(1)]
        /// <summary>�q���ʂ�ID</summary>
        public int ChildId { get; }

    }
}