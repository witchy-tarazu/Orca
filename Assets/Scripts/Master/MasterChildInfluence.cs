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
        /// <summary>�q���ʂ�ID</summary>
        public int ChildId { get; }

        [SecondaryKey(0, 0)]
        public ChildInfluenceParentType ParentType { get; }

        /// <summary>�e����ID</summary>
        [SecondaryKey(0, 1)]
        public int ParentId { get; }

        /// <summary>�q���ʂ̔�������</summary>
        public ChildTriggerCondition TriggerCondition { get; }

        /// <summary>����ΏۃT�C�h</summary>
        public InfluenceCheckSide CheckSide { get; }

        /// <summary>���ʃ^�C�v</summary>
        public InfluenceType InfluenceType { get; }

        /// <summary>�x�[�X�̒l</summary>
        public int BaseValue { get; }

        /// <summary>�O���[�h�ɂ���ĕς��l</summary>
        public int PropotionalValue { get; }
    }
}