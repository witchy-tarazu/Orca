using System;
using System.Collections.Generic;

namespace Orca
{
    public class ProjectileFactory
    {
        private Queue<Projectile> ProjectileQueue { get; set; }

        private Action<HitData, Projectile> ProcessHitAction { get; set; }

        private BattleStage Stage { get; set; }
        private MemoryDatabase MasterDatabase { get; set; }

        private Action<CheckData, IHitChecker> CheckAction { get; set; }

        public ProjectileFactory(
            BattleStage stage,
            MemoryDatabase masterDatabase,
            Action<CheckData, IHitChecker> checkAction,
            Action<HitData, Projectile> processHitAction)
        {
            Stage = stage;
            MasterDatabase = masterDatabase;
            CheckAction = checkAction;
            ProcessHitAction = processHitAction;
            ProjectileQueue = new();
        }

        public HashSet<Projectile> CreateProjectiles(
            ActorHealth ownerHealthContainer,
            MasterCard card,
            Action<IUpdatable> releaseCallback)
        {
            var details = MasterDatabase.MasterCardDetailTable.FindByCardId(card.CardId);
            var position = Stage.GetPanel(ownerHealthContainer).Position;
            HashSet<Projectile> result = new();

            foreach (var detail in details)
            {
                var masterInfluence = MasterDatabase.MasterProjectileTable.FindByProjectileId(detail.DetailId);
                var projectile = CreateProjectile(masterInfluence, card.Grade, ownerHealthContainer, position, releaseCallback);
                result.Add(projectile);
            }

            return result;
        }

        public Projectile CreateProjectile(
            int projectileId,
            int grade,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition,
            Action<IUpdatable> releaseCallback)
        {
            var master = MasterDatabase.MasterProjectileTable.FindByProjectileId(projectileId);
            return CreateProjectile(master, grade, ownerHealth, ownerPosition, releaseCallback);
        }


        public Projectile CreateProjectile(
            MasterProjectile master,
            int grade,
            ActorHealth ownerHealth,
            PanelPosition ownerPosition,
            Action<IUpdatable> releaseCallback)
        {
            Projectile projectile = GetProjectile(master);
            BattleCallbackContainer callbackContainer =
                new(CheckAction,
                    hitData => ProcessHitAction.Invoke(hitData, projectile),
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
            projectile.Setup(projectileData, grade, Stage);

            var children = MasterDatabase.MasterChildInfluenceTable
                .FindByParentTypeAndParentId((ChildInfluenceParentType.Projectile, master.ProjectileId));
            foreach (var childMaster in children)
            {
                ChildInfluencer childInfluencer = new(childMaster);
                projectile.AppendChild(childInfluencer);
            }

            return projectile;
        }

        private Projectile GetProjectile(MasterProjectile master)
        {
            return ProjectileQueue.Dequeue();
        }

        private void Release(Projectile projectile)
        {
            ProjectileQueue.Enqueue(projectile);
        }
    }
}