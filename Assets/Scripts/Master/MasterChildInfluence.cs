using MasterMemory;
using MessagePack;

namespace Orca
{
    public enum ChildTriggerCondition
    {
        Hit,
        Damage,
    }

    public enum ChildInfluenceParentType
    {
        Influence,
        Projectile,
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
            ActorState actorState,
            InfluencePenetrationType penetrationType,
            int baseValue,
            int propotionalValue)
        {
            ChildId = childId;
            ParentType = parentType;
            ParentId = parentId;
            TriggerCondition = triggerCondition;
            CheckSide = checkSide;
            InfluenceType = influenceType;
            ActorState = actorState;
            PenetrationType = penetrationType;
            BaseValue = baseValue;
            PromotionalValue = propotionalValue;
        }

        [PrimaryKey]
        /// <summary>�q���ʂ�ID</summary>
        public int ChildId { get; }

        [SecondaryKey(0, 0), NonUnique]
        public ChildInfluenceParentType ParentType { get; }

        /// <summary>�e����ID</summary>
        [SecondaryKey(0, 1), NonUnique]
        public int ParentId { get; }

        /// <summary>�q���ʂ̔�������</summary>
        public ChildTriggerCondition TriggerCondition { get; }

        /// <summary>����ΏۃT�C�h</summary>
        public InfluenceCheckSide CheckSide { get; }

        /// <summary>���ʃ^�C�v</summary>
        public InfluenceType InfluenceType { get; }

        public ActorState ActorState { get; }

        /// <summary>�ђʃ^�C�v</summary>
        public InfluencePenetrationType PenetrationType { get; }

        /// <summary>�x�[�X�̒l</summary>
        public int BaseValue { get; }

        /// <summary>�O���[�h�ɂ���ĕς��l</summary>
        public int PromotionalValue { get; }
    }
}