using System;
using System.Collections.Generic;

namespace Orca
{
    public class ProjectileFactory
    {
        private Queue<Projectile> ProjectileQueue { get; set; } = new();
        private Action<(int, IUpdatable)> RegisterToSystem { get; set; }
        private Action<(int, IUpdatable)> RemoveFromSystem { get; set; }

        public ProjectileFactory(
            Action<(int, IUpdatable)> registerToSystem,
            Action<(int, IUpdatable)> removeFromSystem)
        {
            RegisterToSystem = registerToSystem;
            RemoveFromSystem = removeFromSystem;
        }

        public HashSet<(int, Projectile)> CreateProjectiles(
            ActorSide ownerSide,
            ActorHealth ownerHealthContainer,
            int parentIndex,
            BattleCard card,
            Action<Projectile> releaseCallback)
        {
            return new() { CreateProjectile(ownerSide, ownerHealthContainer, parentIndex, null, releaseCallback) };
        }

        public (int, Projectile) CreateProjectile(
            ActorSide ownerSide,
            ActorHealth ownerHealthContainer,
            int parentIndex,
            BattleEffect effect,
            Action<Projectile> releaseCallback)
        {
            Projectile projectile = null;

            return (0, projectile);
        }

        private void Release(Projectile projectile)
        {
            ProjectileQueue.Enqueue(projectile);
        }
    }
}