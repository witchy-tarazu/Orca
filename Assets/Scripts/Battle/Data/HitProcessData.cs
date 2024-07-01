using System;

namespace Orca
{
    public struct HitProcessData
    {
        public InfluenceType Type { get; }
        public ActorState ActorState { get; }
        public InfluencePenetrationType PenetrationType { get; }
        public int Value { get; }
        public HitData HitData { get; }
        public ActorHealth OwnerHealth { get; }
        public Action<ActorHealth> OnDamageAction { get; }
        public int Serial { get; }

        public HitProcessData(
            InfluenceType type,
            ActorState actorState,
            InfluencePenetrationType penetrationType,
            int value,
            HitData hitData,
            ActorHealth ownerHealth,
            Action<ActorHealth> onDamageAction,
            int serial)
        {
            Type = type;
            ActorState = actorState;
            PenetrationType = penetrationType;
            Value = value;
            HitData = hitData;
            OwnerHealth = ownerHealth;
            OnDamageAction = onDamageAction;
            Serial = serial;
        }
    }
}
