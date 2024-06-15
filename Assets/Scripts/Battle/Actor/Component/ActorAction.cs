using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using System;

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
        private BattleStage Stage { get; set; }

        public void Initialize(
            InfluencerFactory factory,
            ActorHealth health)
        {
            Factory = factory;
            Health = health;
        }

        public void Execute(MasterCard card, ActorHealth container, PanelPosition position)
        {
            CurrentFrame = 0;
            CurrentState = State.Active;
            FinishFrame = 0;    // TODO: cardÇ©ÇÁê›íËÇ∑ÇÈ

            // TODO: cardÇÃê›íËÇ≈ProjectileÇ©InfluencerÇ«ÇøÇÁÇê∂ê¨Ç∑ÇÈÇ©ï™äÚÇ∑ÇÈ
            var influencers = Factory.CreateInfluencers(container, position, card, OnReleaseInfluencer);
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

            var children = influencer.Children;
            if (children.Count == 0) { return; }

            foreach (var child in children)
            {
                var childInfluence = child.MasterInfluence;
                if (!child.IsSatisfied
                    || childInfluence.ParentType != InfluenceParentType.Actor)
                {
                    continue;
                }

                int executeFrame = CurrentFrame + 1;
                var newInfluencer = Factory.CreateInfluencer(
                    childInfluence,
                    Health,
                    child.Position,
                    OnReleaseInfluencer);
                ReservedInfluencers.Add(newInfluencer);
                FinishFrame += childInfluence.FinishFrame + 1;
            }
        }
    }
}