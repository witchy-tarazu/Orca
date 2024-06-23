using System;

namespace Orca
{
    public struct HitProcessData
    {
        public InfluenceType Type { get; }
        public ActorState ActorState { get; }
        public InfluencePenetrationType PenetrationType { get; }
        public int BaseValue { get; }
        public int PromotionalValue { get; }
        public int Grade { get; }
        public HitData HitData { get; }
        public ActorHealth OwnerHealth { get; }
        public Action<ActorHealth> OnDamageAction { get; }

        public HitProcessData(
            InfluenceType type,
            ActorState actorState,
            InfluencePenetrationType penetrationType,
            int baseValue,
            int promotionalValue,
            int grade,
            HitData hitData,
            ActorHealth ownerHealth,
            Action<ActorHealth> onDamageAction)
        {
            Type = type;
            ActorState = actorState;
            PenetrationType = penetrationType;
            BaseValue = baseValue;
            PromotionalValue = promotionalValue;
            Grade = grade;
            HitData = hitData;
            OwnerHealth = ownerHealth;
            OnDamageAction = onDamageAction;
        }
    }
}
