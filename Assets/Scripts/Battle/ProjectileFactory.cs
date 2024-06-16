using System;
using System.Collections.Generic;

namespace Orca
{
    public class ProjectileFactory
    {
        private Queue<ParabolaProjectile> ParabolaProjectileQueue { get; set; } = new();
        private Queue<LinearProjectile> LinearProjectileQueue { get; set; } = new();
        private Action<IUpdatable> RegisterActionForStage { get; set; }
        private Action<IUpdatable> RemoveActionForStage { get; set; }

        private BattleStage Stage { get; set; }
        private MemoryDatabase MasterDatabase { get; set; }

        private Action<CheckData, IHitChecker> CheckAction { get; set; }

        public ProjectileFactory(
            Action<IUpdatable> registerToSystem,
            Action<IUpdatable> removeFromSystem)
        {
            RegisterActionForStage = registerToSystem;
            RemoveActionForStage = removeFromSystem;
        }

        public Projectile CreateProjectile(
            MasterProjectile master,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition,
            Action<Projectile> releaseCallback)
        {
            Projectile projectile = GetProjectile(master);
            BattleCallbackContainer callbackContainer =
                new(CheckAction,
                    hitData => ProcessHit(hitData, projectile, ownerHealth, ownerPosition),
                    () =>
                    {
                        releaseCallback.Invoke(projectile);
                        Release(projectile);
                    }
                );
            int startPosition = master.StartType switch
            {
                ProjetileStartType.Center => Stage.GetLinearPositonEdge(ownerPosition, ownerHealth.Side),
                ProjetileStartType.Edge => Stage.GetLinearPositonEdge(ownerPosition, ownerHealth.Side),
                _ => 0,
            };

            ProjectileData projectileData = new(ownerHealth, startPosition, master, callbackContainer);
            projectile.Setup(projectileData, ownerHealth, Stage);

            return projectile;
        }

        private Projectile GetProjectile(MasterProjectile master)
        {
            return master.ProjectileType switch
            {
                ProjectileType.Linear => (LinearProjectileQueue.Count > 0) ? LinearProjectileQueue.Dequeue() : new(),
                ProjectileType.Parabola => (ParabolaProjectileQueue.Count > 0) ? ParabolaProjectileQueue.Dequeue() : new(),
                _ => null,
            };
        }

        private void Release(Projectile projectile)
        {
            if (projectile is LinearProjectile)
            {
                LinearProjectileQueue.Enqueue(projectile as LinearProjectile);
            }
            else
            {
                ParabolaProjectileQueue.Enqueue(projectile as ParabolaProjectile);
            }
        }

        private void ProcessHit(
            HitData hitData,
            Projectile projectile,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition)
        {

        }
    }
}