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
        /// <summary>子効果のID</summary>
        public int ChildId { get; }

        /// <summary>親効果ID</summary>
        [SecondaryKey(0), NonUnique]
        public int ParentId { get; }

        /// <summary>子効果の発動条件</summary>
        public ChildTriggerCondition TriggerCondition { get; }

        /// <summary>判定対象サイド</summary>
        public InfluenceCheckSide CheckSide { get; }

        /// <summary>効果タイプ</summary>
        public InfluenceType InfluenceType { get; }

        public ActorState ActorState { get; }

        /// <summary>貫通タイプ</summary>
        public InfluencePenetrationType PenetrationType { get; }

        /// <summary>ベースの値</summary>
        public int Value { get; }
    }
}