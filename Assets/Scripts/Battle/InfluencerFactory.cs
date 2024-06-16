using System;
using System.Collections.Generic;
using System.Linq;

namespace Orca
{
    public class InfluencerFactory
    {
        private Queue<Influencer> InfluencerQueue { get; set; } = new();

        private Action<IUpdatable> RegisterActionForStage { get; set; }
        private Action<IUpdatable> RemoveActionForStage { get; set; }

        private BattleStage Stage { get; set; }
        private MemoryDatabase MasterDatabase { get; set; }

        private Action<CheckData, IHitChecker> CheckAction { get; set; }

        public InfluencerFactory(
            Action<IUpdatable> registerAction,
            Action<IUpdatable> removeAction,
            BattleStage stage,
            MemoryDatabase masterDatabase,
            Action<CheckData, IHitChecker> checkAction)
        {
            RegisterActionForStage = registerAction;
            RemoveActionForStage = removeAction;
            Stage = stage;
            MasterDatabase = masterDatabase;
            CheckAction = checkAction;
        }

        public HashSet<Influencer> CreateInfluencers(
            ActorHealth ownerHealthContainer,
            MasterCard card,
            Action<Influencer> releaseCallback)
        {
            var details = MasterDatabase.MasterCardDetailTable.FindByCardId(card.CardId);
            var position = Stage.GetPanel(ownerHealthContainer).Position;
            HashSet<Influencer> result = new();

            foreach (var detail in details)
            {
                var masterInfluence = MasterDatabase.MasterInfluenceTable.FindByInfluenceId(detail.DetailId);
                var influencer = CreateInfluencer(masterInfluence, ownerHealthContainer, position, releaseCallback);
                result.Add(influencer);
            }

            return result;
        }

        public Influencer CreateInfluencer(
            MasterInfluence master,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition,
            Action<Influencer> releaseCallback)
        {
            Influencer influencer = (InfluencerQueue.Count > 0) ? InfluencerQueue.Dequeue() : new();
            BattleCallbackContainer callbackContainer =
                new(CheckAction,
                    hitData => ProcessHit(hitData, influencer, ownerHealth, ownerPosition),
                    () =>
                    {
                        releaseCallback.Invoke(influencer);
                        Release(influencer);
                    }
                );
            influencer.Setup(master, ownerHealth, ownerPosition, callbackContainer, Stage);

            return influencer;
        }

        private void Release(Influencer influencer)
        {
            InfluencerQueue.Enqueue(influencer);
        }

        private void ProcessHit(
            HitData hitData,
            Influencer influencer,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition)
        {

        }
    }
}