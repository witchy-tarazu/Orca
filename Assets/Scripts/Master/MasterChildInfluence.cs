using MasterMemory;
using MessagePack;

namespace Orca
{
    public enum ChildTriggerCondition
    {
        Hit,
        Damage,
    }

    [MemoryTable("child_influence"), MessagePackObject(true)]
    public class MasterChildInfluence
    {
        public MasterChildInfluence(
            int childId,
            int parentId,
            ChildTriggerCondition triggerCondition,
            InfluenceCheckSide checkSide,
            InfluenceType influenceType,
            ActorState actorState,
            InfluencePenetrationType penetrationType,
            int value)
        {
            ChildId = childId;
            ParentId = parentId;
            TriggerCondition = triggerCondition;
            CheckSide = checkSide;
            InfluenceType = influenceType;
            ActorState = actorState;
            PenetrationType = penetrationType;
            Value = value;
        }

        [PrimaryKey]
        /// <summary>�q���ʂ�ID</summary>
        public int ChildId { get; }

        /// <summary>�e����ID</summary>
        [SecondaryKey(0), NonUnique]
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
        public int Value { get; }
    }
}