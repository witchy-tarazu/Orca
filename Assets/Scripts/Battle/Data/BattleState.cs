using System;

namespace Orca
{
    public class BattleState
    {
        public ActorState State { get; private set; }
        private int RemainFrame { get; set; }
        private int FrameCountForApply { get; set; }
        private Action<ActorState> ApplyAction { get; set; }

        public bool IsEnable => RemainFrame > 0;

        private const int ApplyFrame = 60;

        public BattleState(ActorState state, Action<ActorState> applyAction)
        {
            State = state;
            ApplyAction = applyAction;
            RemainFrame = 0;
            FrameCountForApply = 0;
        }

        public void Update()
        {
            FrameCountForApply++;

            if (FrameCountForApply == ApplyFrame)
            {
                ApplyAction.Invoke(State);
                ResetRemainFrame();
            }
        }

        public void Consume(int value)
        {
            RemainFrame -= value;

            if (RemainFrame < 0) { ResetRemainFrame(); }
        }

        public void AddFrame(int frame)
        {
            RemainFrame += frame;
        }

        public void ResetRemainFrame()
        {
            RemainFrame = 0;
        }
    }
}