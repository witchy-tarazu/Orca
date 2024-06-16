using MessagePack.Formatters.Orca;
using System.Collections.Generic;

namespace Orca
{

    public class Influencer : IHitChecker, IUpdatable
    {
        public HashSet<ChildInfluencer> Children { get; set; } = new();

        public InfluenceParentType InfluencerParentType { get; private set; }

        public ActorHealth OwnerHealth { get; private set; }

        private int CurrentFrame { get; set; }

        private int StartFrame { get; set; }


        private int ActiveFrame { get; set; }

        private int FinishFrame { get; set; }

        private PanelPosition OwnerPosition { get; set; }

        private HashSet<PanelPosition> InfluencePositions { get; set; }

        private BattleCallbackContainer CallbackContainer { get; set; }

        private MasterInfluence Master { get; set; }


        public void Setup(
            MasterInfluence master,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition,
            BattleCallbackContainer callbackContainer,
            BattleStage stage)
        {
            InfluencerParentType = master.ParentType;
            OwnerHealth = ownerHealth;
            CurrentFrame = 0;
            StartFrame = master.StartFrame;
            ActiveFrame = StartFrame + master.Duration - 1;
            FinishFrame = master.FinishFrame;
            OwnerPosition = ownerPosition;
            CallbackContainer = callbackContainer;
            Children.Clear();

            InfluencePositions = stage.GetPanelPositions(ownerHealth, ownerPosition, master);
        }

        public void AppendChild(ChildInfluencer child)
        {
            Children.Add(child);
        }

        public void Update()
        {
            CurrentFrame++;

            if (CurrentFrame < StartFrame
                || CurrentFrame > ActiveFrame)
            {
                return;
            }

            CheckData checkData = new(
                InfluencePositions,
                OwnerHealth,
                InfluenceCheckSide.Opponent,
                ConvertCheckType(Master.TargetType),
                InfluenceCheckRangeType.Panel);
            CallbackContainer.Check(checkData, this);
        }

        public void Hit(HitData hitData)
        {
            CallbackContainer.Hit(hitData);
        }

        public void LateUpdate()
        {
            if (CurrentFrame == FinishFrame)
            {
                CallbackContainer.Release();
            }
        }

        private InfluenceCheckTargetType ConvertCheckType(InfluenceTargetType type)
        {
            return type switch
            {
                InfluenceTargetType.Self => InfluenceCheckTargetType.Self,
                InfluenceTargetType.Whole => InfluenceCheckTargetType.Whole,
                InfluenceTargetType.AbsolutePosition => InfluenceCheckTargetType.Position,
                InfluenceTargetType.RelativePosition => InfluenceCheckTargetType.Position,
                _ => InfluenceCheckTargetType.Self,
            };
        }
    }
}