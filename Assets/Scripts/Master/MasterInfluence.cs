using MasterMemory;
using MessagePack;

namespace Orca
{
    public enum CheckSide
    {
        Whole,
        Owner,
        Opponent,
    }

    public enum CheckRange
    {
        Self,
        Position,
        RelativePanelIndex,
        AbsolutePanelIndex,
        Whole,
    }

    public enum CheckType
    {
        Single,
        Panel,
    }

    public enum InfluenceType
    {
        Damage,

    }

    [MemoryTable("influence"), MessagePackObject(true)]
    public class MasterInfluence
    {
        public MasterInfluence(
            int influenceId,
            InfluenceType influenceType,
            int baseValue,
            int propotionalValue,
            int duration,
            CheckSide checkSide,
            CheckRange checkRange,
            CheckType checkType,
            int checkValueMin,
            int checkValueMax)
        {
            InfluenceId = influenceId;
            InfluenceType = influenceType;
            BaseValue = baseValue;
            PropotionalValue = propotionalValue;
            Duration = duration;
            CheckSide = checkSide;
            CheckRange = checkRange;
            CheckType = checkType;
            CheckValueMin = checkValueMin;
            CheckValueMax = checkValueMax;
        }

        [PrimaryKey]
        public int InfluenceId { get; }

        /// <summary>���ʃ^�C�v</summary>
        public InfluenceType InfluenceType { get; }

        /// <summary>�x�[�X�̒l</summary>
        public int BaseValue { get; }

        /// <summary>�O���[�h�ɂ���ĕς��l</summary>
        public int PropotionalValue { get; }

        /// <summary>����̎c�鎞��</summary>
        public int Duration { get; }

        // �����蔻��֘A
        /// <summary>����ΏۃT�C�h</summary>
        public CheckSide CheckSide { get; }
        /// <summary>����Ώۂ̎擾�`��</summary>
        public CheckRange CheckRange { get; }
        /// <summary>����Ώۂ̎擾�P��</summary>
        public CheckType CheckType { get; }

        /// <summary>����ΏێQ�l�ŏ��l</summary>
        public int CheckValueMin { get; }

        /// <summary>����ΏێQ�l�ő�l</summary>
        public int CheckValueMax { get; }
    }
}