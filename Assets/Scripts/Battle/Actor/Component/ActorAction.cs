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

        private HashSet<(int, Influencer)> ReservedInfluencers { get; set; } = new();
        private HashSet<(int, Influencer)> RemovedReservation { get; set; } = new();

        private HashSet<Influencer> ActiveInfluencers { get; set; } = new();
        private HashSet<Influencer> FinishedInfluencers { get; set; } = new();

        private ActorSide Side { get; set; }
        private InfluencerFactory Factory { get; set; }

        public void Initialize(
            InfluencerFactory factory,
            ActorSide side)
        {
            Factory = factory;
            Side = side;
        }

        public void Execute(int parentIndex, MasterCard card, ActorHealth container)
        {
            CurrentFrame = 0;
            CurrentState = State.Active;
            FinishFrame = 0;    // TODO: cardÇ©ÇÁê›íËÇ∑ÇÈ

            // TODO: cardÇÃê›íËÇ≈ProjectileÇ©InfluencerÇ«ÇøÇÁÇê∂ê¨Ç∑ÇÈÇ©ï™äÚÇ∑ÇÈ
            var influencers = Factory.CreateInfluencers(container, parentIndex, card, OnReleaseInfluencer);
            ReservedInfluencers.AddRange(influencers);
        }

        public void Update()
        {
            if (CurrentState == State.Inactive) { return; }

            CurrentFrame++;

            foreach (var (frame, influencer) in ReservedInfluencers)
            {
                if (frame == CurrentFrame)
                {
                    ActiveInfluencers.Add(influencer);
                    RemovedReservation.Add((frame, influencer));
                }
            }

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

            foreach (var reservation in RemovedReservation)
            {
                ReservedInfluencers.Remove(reservation);
            }
            ReservedInfluencers.Clear();

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
            RemovedReservation.Clear();
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
                if (!child.IsSatisfied
                    || child.Influencer.InfluencerParentType != Influencer.ParentType.Actor)
                {
                    continue;
                }

                int executeFrame = CurrentFrame + child.ExecuteFrameOffset;
                ReservedInfluencers.Add((executeFrame, child.Influencer));
                FinishFrame += child.AdditionalFinishFrame;
            }
        }
    }
}