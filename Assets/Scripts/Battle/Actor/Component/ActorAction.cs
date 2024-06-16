using System.Collections.Generic;
using Unity.VisualScripting;

namespace Orca
{
    public class ActorAction
    {
        private enum State
        {
            Inactive,
            Active,
        }

        private State CurrentState { get; set; }
        private int CurrentFrame { get; set; }
        private int FinishFrame { get; set; }

        private HashSet<Influencer> ReservedInfluencers { get; set; } = new();

        private HashSet<Influencer> ActiveInfluencers { get; set; } = new();
        private HashSet<Influencer> FinishedInfluencers { get; set; } = new();

        private ActorHealth Health { get; set; }
        private InfluencerFactory Factory { get; set; }

        public void Initialize(
            InfluencerFactory factory,
            ActorHealth health)
        {
            Factory = factory;
            Health = health;
        }

        public void Execute(MasterCard card, ActorHealth health)
        {
            CurrentFrame = 0;
            CurrentState = State.Active;
            FinishFrame = 0;    // TODO: cardÇ©ÇÁê›íËÇ∑ÇÈ

            // TODO: cardÇÃê›íËÇ≈ProjectileÇ©InfluencerÇ«ÇøÇÁÇê∂ê¨Ç∑ÇÈÇ©ï™äÚÇ∑ÇÈ
            var influencers = Factory.CreateInfluencers(health, card, OnReleaseInfluencer);
            ActiveInfluencers.AddRange(influencers);
        }

        public void Update()
        {
            if (CurrentState == State.Inactive) { return; }

            CurrentFrame++;

            foreach (var influencer in ReservedInfluencers)
            {
                ActiveInfluencers.Add(influencer);
            }
            ReservedInfluencers.Clear();

            foreach (var influencer in ActiveInfluencers)
            {
                influencer.Update();
            }
        }

        public void LateUpdate()
        {
            if (CurrentState == State.Inactive) { return; }

            foreach (var influencer in ActiveInfluencers)
            {
                influencer.LateUpdate();
            }

            foreach (var influencer in FinishedInfluencers)
            {
                ActiveInfluencers.Remove(influencer);
            }
            FinishedInfluencers.Clear();

            if (CurrentFrame == FinishFrame) { Cancel(); }
        }

        public void Cancel()
        {
            CurrentState = State.Inactive;
            ReservedInfluencers.Clear();
            ActiveInfluencers.Clear();
            FinishedInfluencers.Clear();
        }

        private void OnReleaseInfluencer(Influencer influencer)
        {
            FinishedInfluencers.Add(influencer);
        }
    }
}