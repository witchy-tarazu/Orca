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

        /// <summary>効果タイプ</summary>
        public InfluenceType InfluenceType { get; }

        /// <summary>ベースの値</summary>
        public int BaseValue { get; }

        /// <summary>グレードによって変わる値</summary>
        public int PropotionalValue { get; }

        /// <summary>判定の残る時間</summary>
        public int Duration { get; }

        // 当たり判定関連
        /// <summary>判定対象サイド</summary>
        public CheckSide CheckSide { get; }
        /// <summary>判定対象の取得形式</summary>
        public CheckRange CheckRange { get; }
        /// <summary>判定対象の取得単位</summary>
        public CheckType CheckType { get; }

        /// <summary>判定対象参考最小値</summary>
        public int CheckValueMin { get; }

        /// <summary>判定対象参考最大値</summary>
        public int CheckValueMax { get; }
    }
}