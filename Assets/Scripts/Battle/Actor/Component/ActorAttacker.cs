using System;
using System.Collections.Generic;

namespace Orca
{
    public class ActorAttacker : IActorAction
    {
        public ActorComponentState CurrentState { get; private set; }
        private int CurrentFrame { get; set; }
        private int FinishFrame { get; set; }

        private HashSet<IUpdatable> ReservedInfluencers { get; set; } = new();

        private HashSet<IUpdatable> ActiveInfluencers { get; set; } = new();
        private HashSet<IUpdatable> FinishedInfluencers { get; set; } = new();

        private ActorHealth Health { get; set; }
        private InfluencerFactory InfluencerFactory { get; set; }
        private ProjectileFactory ProjectileFactory { get; set; }

        private Action<IUpdatable> RegisterForSystem { get; set; }

        private Action<IUpdatable> ReleaseForSystem { get; set; }

        public ActorAttacker(
            InfluencerFactory influencerFactory,
            ProjectileFactory projectileFactory,
            Action<IUpdatable> registerForSystem,
            Action<IUpdatable> releaseForSystem,
            ActorHealth health)
        {
            InfluencerFactory = influencerFactory;
            ProjectileFactory = projectileFactory;
            RegisterForSystem = registerForSystem;
            ReleaseForSystem = releaseForSystem;
            Health = health;
        }

        public void Execute(MasterCard card)
        {
            if (Health.IsDazzle)
            {
                Health.DazzleDamage();
                return;
            }

            CurrentFrame = 0;
            CurrentState = ActorComponentState.Active;
            FinishFrame = card.FinishFrame;

            var influencers =
                InfluencerFactory.CreateInfluencers(Health, card, OnReleaseInfluencer, ReleaseForSystem);
            foreach (var influencer in influencers)
            {
                switch (influencer.Master.ParentType)
                {
                    case InfluenceParentType.Actor:
                        ActiveInfluencers.Add(influencer);
                        break;
                    case InfluenceParentType.System:
                        RegisterForSystem(influencer);
                        break;
                };
            }

            var projectiles = ProjectileFactory.CreateProjectiles(Health, card, ReleaseForSystem);
            foreach (var projectile in projectiles)
            {
                RegisterForSystem(projectile);
            }
        }

        public void Update()
        {
            if (CurrentState == ActorComponentState.Inactive) { return; }

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
            if (CurrentState == ActorComponentState.Inactive) { return; }

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
            CurrentState = ActorComponentState.Inactive;
            ReservedInfluencers.Clear();
            ActiveInfluencers.Clear();
            FinishedInfluencers.Clear();
        }

        private void OnReleaseInfluencer(IUpdatable influencer)
        {
            FinishedInfluencers.Add(influencer);
        }
    }
}