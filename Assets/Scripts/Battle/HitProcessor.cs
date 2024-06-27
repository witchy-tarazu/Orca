using System;

namespace Orca
{
    public class HitProcessor
    {
        public Action<int, int, ActorHealth, PanelPosition> CreateInfluencerAction { get; }
        public Action<int, int, ActorHealth, PanelPosition> CreateProjectileAction { get; }

        public HitProcessor(Action<int, int, ActorHealth, PanelPosition> createInfluencerAction, Action<int, int, ActorHealth, PanelPosition> createProjectileAction)
        {
            CreateInfluencerAction = createInfluencerAction;
            CreateProjectileAction = createProjectileAction;
        }

        public void Process(HitData hitData, Influencer influencer)
        {
            var master = influencer.Master;
            int grade = influencer.Grade;
            int value = master.InfluenceType switch
            {
                InfluenceType.CreateInfluence => master.BaseValue,
                InfluenceType.CreateProjectile => master.BaseValue,
                _ => master.BaseValue + master.PromotionalValue * grade,
            };

            HitProcessData processData =
                new(master.InfluenceType,
                    master.ActorState,
                    master.PenetrationType,
                    master.BaseValue,
                    master.PromotionalValue,
                    grade,
                    hitData,
                    influencer.OwnerHealth,
                    (x) => CheckHitForChild(influencer, x),
                    influencer.Serial);

            Process(processData);

            // Hitは必ず適用されるので最後にまとめて処理する
            foreach (var child in influencer.Children)
            {
                child.CheckSatisfaction(ChildTriggerCondition.Hit, hitData);
                if (child.IsSatisfied)
                {
                    var childProcessData = child.CreateHitProcessData(grade, hitData, influencer.OwnerHealth);
                    Process(childProcessData);
                }
            }
        }

        private void CheckHitForChild(Influencer influencer, ActorHealth health)
        {
            foreach (var child in influencer.Children)
            {
                child.CheckSatisfaction(ChildTriggerCondition.Damage, health);
            }
        }

        private void Process(HitProcessData data)
        {
            switch (data.Type)
            {
                case InfluenceType.Damage:
                    data.HitData.ApplyToActors(x =>
                        x.Damage(data.BaseValue + data.PromotionalValue * data.Grade, data.PenetrationType, data.OwnerHealth, data.OnDamageAction, data.Serial));
                    break;
                case InfluenceType.Recovery:
                    data.HitData.ApplyToActors(x => x.Recovery(data.BaseValue + data.PromotionalValue * data.Grade, data.Serial));
                    break;
                case InfluenceType.State:
                    data.HitData.ApplyToActors(x =>
                        x.MakeState(data.ActorState, data.BaseValue + data.PromotionalValue * data.Grade, data.OwnerHealth, data.PenetrationType, data.Serial));
                    break;
                case InfluenceType.Stack:
                    data.HitData.ApplyToActors(x =>
                        x.AddStack(data.ActorState, data.BaseValue + data.PromotionalValue * data.Grade, data.OwnerHealth, data.PenetrationType, data.Serial));
                    break;
                case InfluenceType.CreateInfluence:
                    CreateInfluencerAction.Invoke(data.BaseValue, data.Grade, data.OwnerHealth, data.HitData.Panel.Position);
                    break;
                case InfluenceType.CreateProjectile:
                    CreateProjectileAction.Invoke(data.BaseValue, data.Grade, data.OwnerHealth, data.HitData.Panel.Position);
                    break;
            }
        }

        public void Process(
            HitData hitData,
            Projectile projectile)
        {
            // projectileはHit以外の条件がない
            foreach (var child in projectile.Children)
            {
                child.CheckSatisfaction(ChildTriggerCondition.Hit, hitData);
                if (child.IsSatisfied)
                {
                    var childProcessData = child.CreateHitProcessData(projectile.Grade, hitData, projectile.OwnerHealth);
                    Process(childProcessData);
                }
            }
        }
    }
}