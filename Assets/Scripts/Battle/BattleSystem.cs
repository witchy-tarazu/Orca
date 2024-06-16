using System.Collections.Generic;

namespace Orca
{
    public class BattleSystem
    {
        private List<IUpdatable> PlayerList { get; set; } = new();
        private List<IUpdatable> EnemyList { get; set; } = new();
        private List<IUpdatable> PlayerAutonomyList { get; set; } = new();
        private List<IUpdatable> EnemyAutonomyList { get; set; } = new();
        private BattleStage Stage { get; set; }

        public void Update()
        {
            PlayerList.ForEach(x => x.Update());
            EnemyList.ForEach(x => x.Update());
            PlayerAutonomyList.ForEach(x => x.Update());
            EnemyAutonomyList.ForEach(x => x.Update());
        }

        private void Check(CheckData check, IHitChecker hit)
        {
            switch (check.CheckType)
            {
                case InfluenceCheckTargetType.Self:
                    {
                        var panel = Stage.GetPanel(check.OwnerHealth);
                        HitData hitData = new(panel, new() { check.OwnerHealth });
                        hit.Hit(hitData);
                    }
                    break;
                case InfluenceCheckTargetType.Whole:
                    {
                        var panels = Stage.GetAllPanelHasActor();
                        foreach (var panel in panels)
                        {
                            var targetList = panel.ListupHealth(check);
                            if (targetList.Count == 0) { continue; }
                            HitData hitData = new(panel, panel.ListupHealth(check));
                            hit.Hit(hitData);
                        }
                    }
                    break;
                case InfluenceCheckTargetType.Position:
                    CheckByPosition(check, hit);
                    break;
            }
        }

        private void CheckByPosition(CheckData check, IHitChecker hit)
        {
            switch (check.CheckTargetType)
            {
                case InfluenceCheckRangeType.Single:
                    {
                        var panel = Stage.GetNearestPanel(check);
                        HitData hitData = new(panel, panel.ListupHealth(check));
                        hit.Hit(hitData);
                    }
                    return;
                case InfluenceCheckRangeType.Panel:
                    check.ApplyToPositions(
                    position =>
                    {
                        var panel = Stage.GetPanel(position);
                        var targetList = panel.ListupHealth(check);
                        if (targetList.Count == 0) { return; }
                        HitData hitData = new(panel, targetList);
                        hit.Hit(hitData);
                    });
                    return;
            }
        }
    }
}