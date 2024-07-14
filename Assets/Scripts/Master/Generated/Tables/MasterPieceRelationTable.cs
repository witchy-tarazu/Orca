// <auto-generated />
#pragma warning disable CS0105
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using Orca;
using System.Collections.Generic;
using System;

namespace Orca.Tables
{
   public sealed partial class MasterPieceRelationTable : TableBase<MasterPieceRelation>, ITableUniqueValidate
   {
        public Func<MasterPieceRelation, (int PieceId, int Grade)> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<MasterPieceRelation, (int PieceId, int Grade)> primaryIndexSelector;

        readonly MasterPieceRelation[] secondaryIndex0;
        readonly Func<MasterPieceRelation, int> secondaryIndex0Selector;

        public MasterPieceRelationTable(MasterPieceRelation[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => (x.PieceId, x.Grade);
            this.secondaryIndex0Selector = x => x.PieceId;
            this.secondaryIndex0 = CloneAndSortBy(this.secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default);
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();

        public RangeView<MasterPieceRelation> SortByPieceId => new RangeView<MasterPieceRelation>(secondaryIndex0, 0, secondaryIndex0.Length - 1, true);

        public MasterPieceRelation FindByPieceIdAndGrade((int PieceId, int Grade) key)
        {
            return FindUniqueCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default, key, true);
        }
        
        public bool TryFindByPieceIdAndGrade((int PieceId, int Grade) key, out MasterPieceRelation result)
        {
            return TryFindUniqueCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default, key, out result);
        }

        public MasterPieceRelation FindClosestByPieceIdAndGrade((int PieceId, int Grade) key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default, key, selectLower);
        }

        public RangeView<MasterPieceRelation> FindRangeByPieceIdAndGrade((int PieceId, int Grade) min, (int PieceId, int Grade) max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default, min, max, ascendant);
        }

        public RangeView<MasterPieceRelation> FindByPieceId(int key)
        {
            return FindManyCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key);
        }

        public RangeView<MasterPieceRelation> FindClosestByPieceId(int key, bool selectLower = true)
        {
            return FindManyClosestCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<MasterPieceRelation> FindRangeByPieceId(int min, int max, bool ascendant = true)
        {
            return FindManyRangeCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "(PieceId, Grade)", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(MasterPieceRelation), typeof(MasterPieceRelationTable), "piece_relation",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(MasterPieceRelation).GetProperty("PieceId")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterPieceRelation).GetProperty("Grade")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterPieceRelation).GetProperty("CardId")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterPieceRelation).GetProperty("PieceId"),
                        typeof(MasterPieceRelation).GetProperty("Grade"),
                    }, true, true, System.Collections.Generic.Comparer<(int PieceId, int Grade)>.Default),
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterPieceRelation).GetProperty("PieceId"),
                    }, false, false, System.Collections.Generic.Comparer<int>.Default),
                });
        }

#endif
    }
}