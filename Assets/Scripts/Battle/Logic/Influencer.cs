using System.Collections.Generic;

namespace Orca
{

    public class Influencer : IHitChecker, IUpdatable
    {
        public HashSet<ChildInfluencer> Children { get; set; } = new();

        public ActorHealth OwnerHealth { get; private set; }

        private int CurrentFrame { get; set; }

        private int StartFrame { get; set; }

        private int ActiveFrame { get; set; }

        private int FinishFrame { get; set; }

        private HashSet<PanelPosition> InfluencePositions { get; set; }

        private BattleCallbackContainer CallbackContainer { get; set; }

        public MasterInfluence Master { get; private set; }
        public int Serial { get; private set; }

        public void Setup(
            MasterInfluence master,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition,
            BattleCallbackContainer callbackContainer,
            BattleStage stage,
            int serial)
        {
            Master = master;
            OwnerHealth = ownerHealth;
            CurrentFrame = 0;
            StartFrame = Master.StartFrame;
            ActiveFrame = StartFrame + Master.Duration - 1;
            FinishFrame = Master.FinishFrame;
            CallbackContainer = callbackContainer;
            Children.Clear();
            Serial = serial;

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