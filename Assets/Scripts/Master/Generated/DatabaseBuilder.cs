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
   public sealed class DatabaseBuilder : DatabaseBuilderBase
   {
        public DatabaseBuilder() : this(null) { }
        public DatabaseBuilder(MessagePack.IFormatterResolver resolver) : base(resolver) { }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterBossBattleLayout> dataSource)
        {
            AppendCore(dataSource, x => (x.LayoutId, x.EnemyId), System.Collections.Generic.Comparer<(int LayoutId, int EnemyId)>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterCard> dataSource)
        {
            AppendCore(dataSource, x => x.CardId, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterCardDetail> dataSource)
        {
            AppendCore(dataSource, x => (x.CardId, x.DetailId), System.Collections.Generic.Comparer<(int CardId, int DetailId)>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterChildInfluence> dataSource)
        {
            AppendCore(dataSource, x => x.ChildId, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterEnemy> dataSource)
        {
            AppendCore(dataSource, x => x.Id, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterEnemyBattleLayout> dataSource)
        {
            AppendCore(dataSource, x => (x.LayoutId, x.RoleType, x.PositionIndex), System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterEnemyCommand> dataSource)
        {
            AppendCore(dataSource, x => (x.PatternId, x.Index), System.Collections.Generic.Comparer<(int PatternId, int Index)>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterInfluence> dataSource)
        {
            AppendCore(dataSource, x => x.InfluenceId, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterLayoutLottery> dataSource)
        {
            AppendCore(dataSource, x => (x.StageId, x.LayoutId), System.Collections.Generic.Comparer<(int StageId, int LayoutId)>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterPiece> dataSource)
        {
            AppendCore(dataSource, x => (x.PieceId, x.Grade), System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterPieceDescription> dataSource)
        {
            AppendCore(dataSource, x => x.PieceId, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterProjectile> dataSource)
        {
            AppendCore(dataSource, x => x.ProjectileId, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterStage> dataSource)
        {
            AppendCore(dataSource, x => (x.Id, x.PanelIndex), System.Collections.Generic.Comparer<(int Id, int PanelIndex)>.Default);
            return this;
        }

    }
}