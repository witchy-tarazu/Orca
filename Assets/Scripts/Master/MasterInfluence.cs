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

    }

    public enum InfluenceParentType
    {
        System,
        Actor,
    }

    [MemoryTable("influence"), MessagePackObject(true)]
    public class MasterInfluence
    {
        public MasterInfluence(
            int influenceId,
            InfluenceType influenceType,
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
            BaseValue = baseValue;
            PropotionalValue = propotionalValue;
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

        /// <summary>効果タイプ</summary>
        public InfluenceType InfluenceType { get; }

        /// <summary>ベースの値</summary>
        public int BaseValue { get; }

        /// <summary>グレードによって変わる値</summary>
        public int PropotionalValue { get; }

        /// <summary>判定が発生するまでの時間</summary>
        public int StartFrame { get; }

        /// <summary>判定の残る時間</summary>
        public int Duration { get; }

        /// <summary>全体有効時間</summary>
        public int FinishFrame { get; }

        // 当たり判定関連
        public InfluenceParentType ParentType { get; }
        /// <summary>判定対象の取得形式</summary>
        public InfluenceTargetType TargetType { get; }
        /// <summary>判定対象サイド</summary>
        public InfluenceCheckSide CheckSide { get; }
        /// <summary>判定対象の取得単位</summary>
        public InfluenceCheckRangeType CheckTargetType { get; }

        /// <summary>判定対象参考最小値</summary>
        public int CheckValueMin { get; }

        /// <summary>判定対象参考最大値</summary>
        public int CheckValueMax { get; }
    }
}