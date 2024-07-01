using System;
using System.Collections.Generic;

namespace Orca
{
    public class InfluencerFactory
    {
        private Queue<Influencer> InfluencerQueue { get; set; }

        private Action<HitData, Influencer> ProcessHitAction { get; set; }

        private BattleStage Stage { get; set; }
        private MemoryDatabase MasterDatabase { get; set; }

        private Action<CheckData, IHitChecker> CheckAction { get; set; }

        private int Serial { get; set; }

        public InfluencerFactory(
            BattleStage stage,
            MemoryDatabase masterDatabase,
            Action<CheckData, IHitChecker> checkAction,
            Action<HitData, Influencer> processHitAction)
        {
            Stage = stage;
            MasterDatabase = masterDatabase;
            CheckAction = checkAction;
            ProcessHitAction = processHitAction;
            InfluencerQueue = new();
            Serial = 0;
        }

        public HashSet<Influencer> CreateInfluencers(
            ActorHealth ownerHealthContainer,
            MasterCard card,
            Action<IUpdatable> releaseCallbackForActor,
            Action<IUpdatable> releaseCallbackForSystem)
        {
            var details = MasterDatabase.MasterCardDetailTable.FindByCardId(card.CardId);
            var position = Stage.GetPanel(ownerHealthContainer).Position;
            HashSet<Influencer> result = new();

            foreach (var detail in details)
            {
                var masterInfluence = MasterDatabase.MasterInfluenceTable.FindByInfluenceId(detail.DetailId);
                var releaseCallback =
                    (masterInfluence.ParentType == InfluenceParentType.System) ?
                    releaseCallbackForSystem : releaseCallbackForActor;
                var influencer = CreateInfluencer(masterInfluence, ownerHealthContainer, position, releaseCallback);
                result.Add(influencer);
            }

            return result;
        }

        public Influencer CreateInfluencer(
            int influeceId,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition,
            Action<IUpdatable> releaseCallback)
        {
            var master = MasterDatabase.MasterInfluenceTable.FindByInfluenceId(influeceId);
            return CreateInfluencer(master, ownerHealth, ownerPosition, releaseCallback);
        }

        public Influencer CreateInfluencer(
            MasterInfluence master,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition,
            Action<IUpdatable> releaseCallback)
        {
            Influencer influencer = (InfluencerQueue.Count > 0) ? InfluencerQueue.Dequeue() : new();
            BattleCallbackContainer callbackContainer =
                new(CheckAction,
                    hitData => ProcessHitAction.Invoke(hitData, influencer),
                    () =>
                    {
                        releaseCallback.Invoke(influencer);
                        Release(influencer);
                    }
                );
            influencer.Setup(master, ownerHealth, ownerPosition, callbackContainer, Stage, ++Serial);

            var children = MasterDatabase.MasterChildInfluenceTable
                .FindByParentTypeAndParentId((ChildInfluenceParentType.Influence, master.InfluenceId));
            foreach (var childMaster in children)
            {
                ChildInfluencer childInfluencer = new(childMaster);
                influencer.AppendChild(childInfluencer);
            }

            return influencer;
        }

        private void Release(Influencer influencer)
        {
            InfluencerQueue.Enqueue(influencer);
        }
    }
}