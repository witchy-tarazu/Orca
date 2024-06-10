using System;
using System.Collections.Generic;

namespace Orca
{
    public class InfluencerFactory
    {
        private Queue<Influencer> InfluencerQueue { get; set; } = new();

        private Action<(int, IUpdatable)> RegisterActionForStage { get; set; }
        private Action<(int, IUpdatable)> RemoveActionForStage { get; set; }

        public InfluencerFactory(
            Action<(int, IUpdatable)> registerAction,
            Action<(int, IUpdatable)> removeAction)
        {
            RegisterActionForStage = registerAction;
            RemoveActionForStage = removeAction;
        }

        public HashSet<(int, Influencer)> CreateInfluencers(
            ActorSide ownerSide,
            ActorHealth ownerHealthContainer,
            int parentIndex,
            BattleCard card,
            Action<Influencer> releaseCallback)
        {
            return new() { CreateInfluencer(ownerSide, ownerHealthContainer, parentIndex, null, releaseCallback) };
        }

        public (int, Influencer) CreateInfluencer(
            ActorSide ownerSide,
            ActorHealth ownerHealthContainer,
            int parentIndex,
            BattleEffect effect,
            Action<Influencer> releaseCallback)
        {
            Influencer influencer = (InfluencerQueue.Count > 0) ? InfluencerQueue.Dequeue() : new();
            int executeFrame = 0;
            BattleCallbackContainer callbackContainer =
                new(null,
                    hitData =>
                    {

                    },
                    () =>
                    {
                        releaseCallback.Invoke(influencer);
                        Release(influencer);
                    }
                );
            influencer.Initialize(Influencer.ParentType.Actor, ownerSide, 0, 0, null, callbackContainer);

            return (executeFrame, influencer);
        }

        private void Release(Influencer influencer)
        {
            InfluencerQueue.Enqueue(influencer);
        }

        private void CreateChild()
        {

        }
    }
}