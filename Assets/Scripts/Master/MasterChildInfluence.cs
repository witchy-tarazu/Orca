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

    public enum ChildInfluenceParentType
    {
        Influence,
        Projectile
    }

    [MemoryTable("child_influence"), MessagePackObject(true)]
    public class MasterChildInfluence
    {
        public MasterChildInfluence(
            int childId,
            ChildInfluenceParentType parentType,
            int parentId,
            ChildTriggerCondition triggerCondition,
            InfluenceCheckSide checkSide,
            InfluenceType influenceType,
            int baseValue,
            int propotionalValue)
        {
            ChildId = childId;
            ParentType = parentType;
            ParentId = parentId;
            TriggerCondition = triggerCondition;
            CheckSide = checkSide;
            InfluenceType = influenceType;
            BaseValue = baseValue;
            PropotionalValue = propotionalValue;
        }

        [PrimaryKey]
        /// <summary>子効果のID</summary>
        public int ChildId { get; }

        [SecondaryKey(0, 0), NonUnique]
        public ChildInfluenceParentType ParentType { get; }

        /// <summary>親効果ID</summary>
        [SecondaryKey(0, 1), NonUnique]
        public int ParentId { get; }

        /// <summary>子効果の発動条件</summary>
        public ChildTriggerCondition TriggerCondition { get; }

        /// <summary>判定対象サイド</summary>
        public InfluenceCheckSide CheckSide { get; }

        /// <summary>効果タイプ</summary>
        public InfluenceType InfluenceType { get; }

        /// <summary>ベースの値</summary>
        public int BaseValue { get; }

        /// <summary>グレードによって変わる値</summary>
        public int PropotionalValue { get; }
    }
}