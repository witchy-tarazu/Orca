using System.Collections.Generic;

namespace Orca
{

    public class Influencer : IHitChecker, IUpdatable
    {
        public enum ParentType
        {
            System,
            Actor,
        }

        public HashSet<ChildInfluencer> Children { get; set; } = new();

        public ParentType InfluencerParentType { get; private set; }

        private ActorSide Side { get; set; }

        private int CurrentFrame { get; set; }

        private int EndFrame { get; set; }

        private int ParentIndex { get; set; }

        private List<int> RelativeInfluenceIndexes { get; set; }

        private BattleCallbackContainer CallbackContainer { get; set; }


        public void Initialize(
            ParentType parentType,
            ActorSide side,
            int endFrame,
            int parentIndex,
            List<int> relativeInfluenceIndexes,
            BattleCallbackContainer callbackContainer)
        {
            InfluencerParentType = parentType;
            Side = side;
            CurrentFrame = 0;
            EndFrame = endFrame;
            ParentIndex = parentIndex;
            RelativeInfluenceIndexes = relativeInfluenceIndexes;
            CallbackContainer = callbackContainer;
            Children.Clear();
        }

        public void AppendChild(ChildInfluencer child)
        {
            Children.Add(child);
        }

        public void Update()
        {
            CurrentFrame++;

            foreach (var panelIndex in RelativeInfluenceIndexes)
            {
                CheckData checkData = new(ParentIndex + panelIndex, Side, CheckType.PanelIndex);
                CallbackContainer.Check(checkData, this);
            }
        }

        public void Hit(HitData hitData)
        {
            CallbackContainer.Hit(hitData);
        }

        public void LateUpdate()
        {
            if (CurrentFrame == EndFrame)
            {
                CallbackContainer.Release();
            }
        }
    }
}