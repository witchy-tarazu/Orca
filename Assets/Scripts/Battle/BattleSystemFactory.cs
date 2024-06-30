using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Orca
{
    public class BattleSystemFactory
    {
        public BattleSystem CreateEnemyBattle(
            MemoryDatabase database,
            int stageId,
            int level,
            BattleHeroData heroData,
            BattleResultCallbackContainer resultCallbackContainer)
        {
            var panelList = database.MasterStageTable.FindById(stageId).OrderBy(x => x.PanelIndex).ToList();
            BattleStage stage = new(panelList, BattleDefine.WidthPerPanel);

            // stageIdから抽選可能なlayoutIdを取得
            var layoutList = database.MasterLayoutLotteryTable.FindByStageId(stageId).ToList();
            List<int> weightList = new();
            for (int i = 0; i < layoutList.Count; i++)
            {
                weightList.Add(layoutList[i].Weight);
            }
            int index = Rogue.Lottery.LotIndex(weightList);
            int layoutId = layoutList[index].LayoutId;

            List<ActorPositionData> leftEnemyDataList = new();
            List<ActorPositionData> rightEnemyDataList = new();

            var layoutInfo = database.MasterEnemyBattleLayoutTable.FindByLayoutId(layoutId);
            foreach (var detail in layoutInfo)
            {
                switch (detail.RoleType)
                {
                    case RoleType.Player:
                        heroData.SetStartPosition(new(detail.PositionIndex));
                        break;
                    default:
                        {
                            var targetEnemyList = database.MasterEnemyTable.FindByRoleTypeAndLevel((detail.RoleType, level));
                            var enemy = targetEnemyList.OrderBy(x => Random.Range(0, int.MaxValue)).First();
                            rightEnemyDataList.Add(new(enemy, new(detail.PositionIndex)));
                        }
                        break;
                }
            }

            ActorLayoutData leftLayout = new(leftEnemyDataList, heroData);
            ActorLayoutData rightLayout = new(rightEnemyDataList, null);

            BattleSystem battleSystem = new(database, stage, leftLayout, rightLayout, resultCallbackContainer);
            return battleSystem;
        }

        public BattleSystem CreateBossBattle()
        {
            return null;
        }

        public BattleSystem CreateVersusBattle(
            MemoryDatabase database,
            int stageId,
            BattleHeroData leftHeroData,
            BattleHeroData rightHeroData,
            BattleResultCallbackContainer resultCallbackContainer)
        {
            var panelList = database.MasterStageTable.FindById(stageId).OrderBy(x => x.PanelIndex).ToList();
            BattleStage stage = new(panelList, BattleDefine.WidthPerPanel);

            // stageIdから抽選可能なlayoutIdを取得
            var layoutList = database.MasterLayoutLotteryTable.FindByStageId(stageId).ToList();
            List<int> weightList = new();
            for (int i = 0; i < layoutList.Count; i++)
            {
                weightList.Add(layoutList[i].Weight);
            }
            int index = Rogue.Lottery.LotIndex(weightList);
            int layoutId = layoutList[index].LayoutId;

            List<ActorPositionData> leftEnemyDataList = new();
            List<ActorPositionData> rightEnemyDataList = new();

            var layoutInfo = database.MasterEnemyBattleLayoutTable.FindByLayoutId(layoutId);
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


            BattleSystem battleSystem = new(database, stage, leftLayout, rightLayout, resultCallbackContainer);
            return battleSystem;
        }
    }
}