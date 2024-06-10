using System;

namespace Orca
{
    public class ProjectileData
    {
        public ActorSide Side { get; private set; }
        public int Speed { get; private set; }
        public int StartPos { get; private set; }
        public int Distance { get; private set; }

        private BattleCallbackContainer CallbackContainer { get; set; }

        public ProjectileData(
            ActorSide side,
            int speed,
            int startPos,
            int distance,
            BattleCallbackContainer callbackContainer)
        {
            Side = side;
            Speed = speed;
            StartPos = startPos;
            Distance = distance;
            CallbackContainer = callbackContainer;
        }

        public void Check(CheckData data, IHitChecker checker)
        {
            CallbackContainer.Check(data, checker);
        }

        public void Hit(HitData data)
        {
            CallbackContainer.Hit(data);
        }

        public void Release()
        {
            CallbackContainer.Release();
        }
    }
}