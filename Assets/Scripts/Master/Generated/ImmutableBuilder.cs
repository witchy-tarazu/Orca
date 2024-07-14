// <auto-generated />
#pragma warning disable CS0105
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using Orca;
using System.Collections.Generic;
using System;
using Orca.Tables;

namespace Orca
{
   public sealed class ImmutableBuilder : ImmutableBuilderBase
   {
        MemoryDatabase memory;

        public ImmutableBuilder(MemoryDatabase memory)
        {
            this.memory = memory;
        }

        public MemoryDatabase Build()
        {
            return memory;
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterBossBattleLayout> data)
        {
            var newData = CloneAndSortBy(data, x => (x.LayoutId, x.EnemyId), System.Collections.Generic.Comparer<(int LayoutId, int EnemyId)>.Default);
            var table = new MasterBossBattleLayoutTable(newData);
            memory = new MemoryDatabase(
                table,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void RemoveMasterBossBattleLayout((int LayoutId, int EnemyId)[] keys)
        {
            var data = RemoveCore(memory.MasterBossBattleLayoutTable.GetRawDataUnsafe(), keys, x => (x.LayoutId, x.EnemyId), System.Collections.Generic.Comparer<(int LayoutId, int EnemyId)>.Default);
            var newData = CloneAndSortBy(data, x => (x.LayoutId, x.EnemyId), System.Collections.Generic.Comparer<(int LayoutId, int EnemyId)>.Default);
            var table = new MasterBossBattleLayoutTable(newData);
            memory = new MemoryDatabase(
                table,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void Diff(MasterBossBattleLayout[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterBossBattleLayoutTable.GetRawDataUnsafe(), addOrReplaceData, x => (x.LayoutId, x.EnemyId), System.Collections.Generic.Comparer<(int LayoutId, int EnemyId)>.Default);
            var newData = CloneAndSortBy(data, x => (x.LayoutId, x.EnemyId), System.Collections.Generic.Comparer<(int LayoutId, int EnemyId)>.Default);
            var table = new MasterBossBattleLayoutTable(newData);
            memory = new MemoryDatabase(
                table,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterCard> data)
        {
            var newData = CloneAndSortBy(data, x => x.CardId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterCardTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                table,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void RemoveMasterCard(int[] keys)
        {
            var data = RemoveCore(memory.MasterCardTable.GetRawDataUnsafe(), keys, x => x.CardId, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.CardId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterCardTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                table,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void Diff(MasterCard[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterCardTable.GetRawDataUnsafe(), addOrReplaceData, x => x.CardId, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.CardId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterCardTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                table,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterCardDetail> data)
        {
            var newData = CloneAndSortBy(data, x => (x.CardId, x.DetailId), System.Collections.Generic.Comparer<(int CardId, int DetailId)>.Default);
            var table = new MasterCardDetailTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                table,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void RemoveMasterCardDetail((int CardId, int DetailId)[] keys)
        {
            var data = RemoveCore(memory.MasterCardDetailTable.GetRawDataUnsafe(), keys, x => (x.CardId, x.DetailId), System.Collections.Generic.Comparer<(int CardId, int DetailId)>.Default);
            var newData = CloneAndSortBy(data, x => (x.CardId, x.DetailId), System.Collections.Generic.Comparer<(int CardId, int DetailId)>.Default);
            var table = new MasterCardDetailTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                table,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void Diff(MasterCardDetail[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterCardDetailTable.GetRawDataUnsafe(), addOrReplaceData, x => (x.CardId, x.DetailId), System.Collections.Generic.Comparer<(int CardId, int DetailId)>.Default);
            var newData = CloneAndSortBy(data, x => (x.CardId, x.DetailId), System.Collections.Generic.Comparer<(int CardId, int DetailId)>.Default);
            var table = new MasterCardDetailTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                table,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterChildInfluence> data)
        {
            var newData = CloneAndSortBy(data, x => x.ChildId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterChildInfluenceTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                table,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void RemoveMasterChildInfluence(int[] keys)
        {
            var data = RemoveCore(memory.MasterChildInfluenceTable.GetRawDataUnsafe(), keys, x => x.ChildId, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.ChildId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterChildInfluenceTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                table,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void Diff(MasterChildInfluence[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterChildInfluenceTable.GetRawDataUnsafe(), addOrReplaceData, x => x.ChildId, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.ChildId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterChildInfluenceTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                table,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterEnemy> data)
        {
            var newData = CloneAndSortBy(data, x => x.Id, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterEnemyTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                table,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void RemoveMasterEnemy(int[] keys)
        {
            var data = RemoveCore(memory.MasterEnemyTable.GetRawDataUnsafe(), keys, x => x.Id, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.Id, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterEnemyTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                table,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void Diff(MasterEnemy[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterEnemyTable.GetRawDataUnsafe(), addOrReplaceData, x => x.Id, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.Id, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterEnemyTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                table,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterEnemyBattleLayout> data)
        {
            var newData = CloneAndSortBy(data, x => (x.LayoutId, x.RoleType, x.PositionIndex), System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default);
            var table = new MasterEnemyBattleLayoutTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                table,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void RemoveMasterEnemyBattleLayout((int LayoutId, RoleType RoleType, int PositionIndex)[] keys)
        {
            var data = RemoveCore(memory.MasterEnemyBattleLayoutTable.GetRawDataUnsafe(), keys, x => (x.LayoutId, x.RoleType, x.PositionIndex), System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default);
            var newData = CloneAndSortBy(data, x => (x.LayoutId, x.RoleType, x.PositionIndex), System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default);
            var table = new MasterEnemyBattleLayoutTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                table,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void Diff(MasterEnemyBattleLayout[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterEnemyBattleLayoutTable.GetRawDataUnsafe(), addOrReplaceData, x => (x.LayoutId, x.RoleType, x.PositionIndex), System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default);
            var newData = CloneAndSortBy(data, x => (x.LayoutId, x.RoleType, x.PositionIndex), System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default);
            var table = new MasterEnemyBattleLayoutTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                table,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterEnemyCommand> data)
        {
            var newData = CloneAndSortBy(data, x => (x.PatternId, x.Index), System.Collections.Generic.Comparer<(int PatternId, int Index)>.Default);
            var table = new MasterEnemyCommandTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                table,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }


        public void ReplaceAll(System.Collections.Generic.IList<MasterInfluence> data)
        {
            var newData = CloneAndSortBy(data, x => x.InfluenceId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterInfluenceTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                table,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void RemoveMasterInfluence(int[] keys)
        {
            var data = RemoveCore(memory.MasterInfluenceTable.GetRawDataUnsafe(), keys, x => x.InfluenceId, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.InfluenceId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterInfluenceTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                table,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void Diff(MasterInfluence[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterInfluenceTable.GetRawDataUnsafe(), addOrReplaceData, x => x.InfluenceId, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.InfluenceId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterInfluenceTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                table,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterLayoutLottery> data)
        {
            var newData = CloneAndSortBy(data, x => (x.StageId, x.LayoutId), System.Collections.Generic.Comparer<(int StageId, int LayoutId)>.Default);
            var table = new MasterLayoutLotteryTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                table,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }


        public void ReplaceAll(System.Collections.Generic.IList<MasterPiece> data)
        {
            var newData = CloneAndSortBy(data, x => x.PieceId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterPieceTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                table,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void RemoveMasterPiece(int[] keys)
        {
            var data = RemoveCore(memory.MasterPieceTable.GetRawDataUnsafe(), keys, x => x.PieceId, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.PieceId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterPieceTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                table,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void Diff(MasterPiece[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterPieceTable.GetRawDataUnsafe(), addOrReplaceData, x => x.PieceId, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.PieceId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterPieceTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                table,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterPieceRelation> data)
        {
            var newData = CloneAndSortBy(data, x => (x.PieceId, x.Grade), System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default);
            var table = new MasterPieceRelationTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                table,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void RemoveMasterPieceRelation((int PieceId, int Grade)[] keys)
        {
            var data = RemoveCore(memory.MasterPieceRelationTable.GetRawDataUnsafe(), keys, x => (x.PieceId, x.Grade), System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default);
            var newData = CloneAndSortBy(data, x => (x.PieceId, x.Grade), System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default);
            var table = new MasterPieceRelationTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                table,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void Diff(MasterPieceRelation[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterPieceRelationTable.GetRawDataUnsafe(), addOrReplaceData, x => (x.PieceId, x.Grade), System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default);
            var newData = CloneAndSortBy(data, x => (x.PieceId, x.Grade), System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default);
            var table = new MasterPieceRelationTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                table,
                memory.MasterProjectileTable,
                memory.MasterStageTable
            
            );
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterProjectile> data)
        {
            var newData = CloneAndSortBy(data, x => x.ProjectileId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterProjectileTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                table,
                memory.MasterStageTable
            
            );
        }

        public void RemoveMasterProjectile(int[] keys)
        {
            var data = RemoveCore(memory.MasterProjectileTable.GetRawDataUnsafe(), keys, x => x.ProjectileId, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.ProjectileId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterProjectileTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                table,
                memory.MasterStageTable
            
            );
        }

        public void Diff(MasterProjectile[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterProjectileTable.GetRawDataUnsafe(), addOrReplaceData, x => x.ProjectileId, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.ProjectileId, System.Collections.Generic.Comparer<int>.Default);
            var table = new MasterProjectileTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                table,
                memory.MasterStageTable
            
            );
        }

        public void ReplaceAll(System.Collections.Generic.IList<MasterStage> data)
        {
            var newData = CloneAndSortBy(data, x => (x.Id, x.PanelIndex), System.Collections.Generic.Comparer<(int Id, int PanelIndex)>.Default);
            var table = new MasterStageTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                table
            
            );
        }

        public void RemoveMasterStage((int Id, int PanelIndex)[] keys)
        {
            var data = RemoveCore(memory.MasterStageTable.GetRawDataUnsafe(), keys, x => (x.Id, x.PanelIndex), System.Collections.Generic.Comparer<(int Id, int PanelIndex)>.Default);
            var newData = CloneAndSortBy(data, x => (x.Id, x.PanelIndex), System.Collections.Generic.Comparer<(int Id, int PanelIndex)>.Default);
            var table = new MasterStageTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                table
            
            );
        }

        public void Diff(MasterStage[] addOrReplaceData)
        {
            var data = DiffCore(memory.MasterStageTable.GetRawDataUnsafe(), addOrReplaceData, x => (x.Id, x.PanelIndex), System.Collections.Generic.Comparer<(int Id, int PanelIndex)>.Default);
            var newData = CloneAndSortBy(data, x => (x.Id, x.PanelIndex), System.Collections.Generic.Comparer<(int Id, int PanelIndex)>.Default);
            var table = new MasterStageTable(newData);
            memory = new MemoryDatabase(
                memory.MasterBossBattleLayoutTable,
                memory.MasterCardTable,
                memory.MasterCardDetailTable,
                memory.MasterChildInfluenceTable,
                memory.MasterEnemyTable,
                memory.MasterEnemyBattleLayoutTable,
                memory.MasterEnemyCommandTable,
                memory.MasterInfluenceTable,
                memory.MasterLayoutLotteryTable,
                memory.MasterPieceTable,
                memory.MasterPieceRelationTable,
                memory.MasterProjectileTable,
                table
            
            );
        }

    }
}