using System;

namespace Orca
{
    public class ProjectileData
    {
        public ActorHealth OwnerHealth { get; private set; }
        public int StartPos { get; private set; }

        public MasterProjectile Master { get; private set; }

        private BattleCallbackContainer CallbackContainer { get; set; }

        public ProjectileData(
            ActorHealth ownerHealth,
            int startPos,
            MasterProjectile master,
            BattleCallbackContainer callbackContainer)
        {
            OwnerHealth = ownerHealth;
            StartPos = startPos;
            Master = master;
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