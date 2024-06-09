using System;

namespace Orca
{
    public class ProjectileData
    {
        public int Speed { get; private set; }
        public int StartPos { get; private set; }
        public int Distance { get; private set; }

        private BattleCallbackContainer CallbackContainer { get; set; }

        public ProjectileData(
            int speed,
            int startPos,
            int distance,
             BattleCallbackContainer callbackContainer)
        {
            Speed = speed;
            StartPos = startPos;
            Distance = distance;
            CallbackContainer = callbackContainer;
        }

        public void Check(int detail)
        {
            CallbackContainer.Check(detail);
        }

        public void Hit(HitData hitData)
        {
            CallbackContainer.Hit(hitData);
        }

        public void Release()
        {
            CallbackContainer.Release();
        }
    }
}