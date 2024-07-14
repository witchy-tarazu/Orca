using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Orca
{
    public class BattleSystemFactory
    {
        private MemoryDatabase Database { get; set; }

        public BattleSystemFactory(MemoryDatabase database)
        {
            Database = database;
        }

        public BattleSystem CreateEnemyBattle(
            int stageId,
            int level,
            BattleHeroData heroData,
            BattleResultCallbackContainer resultCallbackContainer)
        {
            var panelList = Database.MasterStageTable.FindById(stageId).OrderBy(x => x.PanelIndex).ToList();
            BattleStage stage = new(panelList, BattleDefine.WidthPerPanel);

            // stageIdから抽選可能なlayoutIdを取得
            var layoutList = Database.MasterLayoutLotteryTable.FindByStageId(stageId).ToList();
            List<int> weightList = new();
            for (int i = 0; i < layoutList.Count; i++)
            {
                weightList.Add(layoutList[i].Weight);
            }
            int index = Rogue.Lottery.LotIndex(weightList);
            int layoutId = layoutList[index].LayoutId;

            List<ActorPositionData> leftEnemyDataList = new();
            List<ActorPositionData> rightEnemyDataList = new();

            var layoutInfo = Database.MasterEnemyBattleLayoutTable.FindByLayoutId(layoutId);
            foreach (var detail in layoutInfo)
            {
                switch (detail.RoleType)
                {
                    case RoleType.Player:
                        heroData.SetStartPosition(new(detail.PositionIndex));
                        break;
                    default:
                        {
                            var targetEnemyList = Database.MasterEnemyTable.FindByRoleTypeAndLevel((detail.RoleType, level));
                            var enemy = targetEnemyList.OrderBy(x => Random.Range(0, int.MaxValue)).First();
                            rightEnemyDataList.Add(new(enemy, new(detail.PositionIndex)));
                        }
                        break;
                }
            }

            ActorLayoutData leftLayout = new(leftEnemyDataList, heroData);
            ActorLayoutData rightLayout = new(rightEnemyDataList, null);

            BattleSystem battleSystem = new(Database, stage, leftLayout, rightLayout, resultCallbackContainer);
            return battleSystem;
        }

        public BattleSystem CreateVersusBattle(
            int stageId,
            BattleHeroData leftHeroData,
            BattleHeroData rightHeroData,
            BattleResultCallbackContainer resultCallbackContainer)
        {
            var panelList = Database.MasterStageTable.FindById(stageId).OrderBy(x => x.PanelIndex).ToList();
            BattleStage stage = new(panelList, BattleDefine.WidthPerPanel);

            // stageIdから抽選可能なlayoutIdを取得
            var layoutList = Database.MasterLayoutLotteryTable.FindByStageId(stageId).ToList();
            List<int> weightList = new();
            for (int i = 0; i < layoutList.Count; i++)
            {
                weightList.Add(layoutList[i].Weight);
            }
            int index = Rogue.Lottery.LotIndex(weightList);
            int layoutId = layoutList[index].LayoutId;

            List<ActorPositionData> leftEnemyDataList = new();
            List<ActorPositionData> rightEnemyDataList = new();

            var layoutInfo = Database.MasterEnemyBattleLayoutTable.FindByLayoutId(layoutId);
            foreach (var detail in layoutInfo)
            {
                switch (detail.RoleType)
                {
                    case RoleType.Player:
                        if (detail.PositionIndex < panelList.Count / 2)
                        {
                            leftHeroData.SetStartPosition(new(detail.PositionIndex));
                        }
                        else
                        {
                            rightHeroData.SetStartPosition(new(detail.PositionIndex));
                        }
                        break;
                }
            }

            ActorLayoutData leftLayout = new(leftEnemyDataList, leftHeroData);
            ActorLayoutData rightLayout = new(rightEnemyDataList, rightHeroData);


            BattleSystem battleSystem = new(Database, stage, leftLayout, rightLayout, resultCallbackContainer);
            return battleSystem;
        }
    }
}