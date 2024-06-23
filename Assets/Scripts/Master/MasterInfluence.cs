using MasterMemory;
using MessagePack;

namespace Orca
{
    public enum InfluenceCheckSide
    {
        Whole,
        Owner,
        Opponent,
    }

    public enum InfluenceTargetType
    {
        Self,
        RelativePosition,
        AbsolutePosition,
        Whole,
    }

    public enum InfluenceCheckTargetType
    {
        Self,
        Position,
        Whole,
    }

    public enum InfluenceCheckRangeType
    {
        Single,
        Panel,
    }

    public enum InfluenceType
    {
        Damage,
        Recovery,
        Stack,
        State,
        CreateInfluence,
        CreateProjectile,
    }

    public enum InfluenceParentType
    {
        System,
        Actor,
    }

    public enum InfluencePenetrationType
    {
        None,
        Barrier,
        Invincible,
        Whole,
    }

    public enum ActorState
    {
        None,

        // ��Ԉُ�
        Poison,
        Darkness,
        Invincible,
        Dazzle,
        Stan,
        Regeneration,

        // �~�ω\�ȏ��
        AttackBuff,
        DefenceBuff,
        Barrier,
        Charge,
        Critical,
        Drain,

    }

    [MemoryTable("influence"), MessagePackObject(true)]
    public class MasterInfluence
    {
        public MasterInfluence(
            int influenceId,
            InfluenceType influenceType,
            ActorState actorState,
            InfluencePenetrationType penetrationType,
            int baseValue,
            int propotionalValue,
            int startFrame,
            int duration,
            int finishFrame,
            InfluenceParentType parentType,
            InfluenceTargetType targetType,
            InfluenceCheckSide checkSide,
            InfluenceCheckRangeType checkTargetType,
            int checkValueMin,
            int checkValueMax)
        {
            InfluenceId = influenceId;
            InfluenceType = influenceType;
            ActorState = actorState;
            PenetrationType = penetrationType;
            BaseValue = baseValue;
            PromotionalValue = propotionalValue;
            StartFrame = startFrame;
            Duration = duration;
            FinishFrame = finishFrame;
            ParentType = parentType;
            TargetType = targetType;
            CheckSide = checkSide;
            CheckTargetType = checkTargetType;
            CheckValueMin = checkValueMin;
            CheckValueMax = checkValueMax;
        }

        [PrimaryKey]
        public int InfluenceId { get; }

        /// <summary>���ʃ^�C�v</summary>
        public InfluenceType InfluenceType { get; }

        public ActorState ActorState { get; }

        /// <summary>�ђʃ^�C�v</summary>
        public InfluencePenetrationType PenetrationType { get; }

        /// <summary>�x�[�X�̒l</summary>
        public int BaseValue { get; }

        /// <summary>�O���[�h�ɂ���ĕς��l</summary>
        public int PromotionalValue { get; }

        /// <summary>���肪��������܂ł̎���</summary>
        public int StartFrame { get; }

        /// <summary>����̎c�鎞��</summary>
        public int Duration { get; }

        /// <summary>�S�̗L������</summary>
        public int FinishFrame { get; }

        // �����蔻��֘A
        public InfluenceParentType ParentType { get; }
        /// <summary>����Ώۂ̎擾�`��</summary>
        public InfluenceTargetType TargetType { get; }
        /// <summary>����ΏۃT�C�h</summary>
        public InfluenceCheckSide CheckSide { get; }
        /// <summary>����Ώۂ̎擾�P��</summary>
        public InfluenceCheckRangeType CheckTargetType { get; }

        /// <summary>����ΏێQ�l�ŏ��l</summary>
        public int CheckValueMin { get; }

        /// <summary>����ΏێQ�l�ő�l</summary>
        public int CheckValueMax { get; }
    }
}