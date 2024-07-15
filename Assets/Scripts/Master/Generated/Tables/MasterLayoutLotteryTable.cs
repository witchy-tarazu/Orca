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
   public sealed partial class MasterLayoutLotteryTable : TableBase<MasterLayoutLottery>, ITableUniqueValidate
   {
        public Func<MasterLayoutLottery, (int StageId, int LayoutId)> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<MasterLayoutLottery, (int StageId, int LayoutId)> primaryIndexSelector;

        readonly MasterLayoutLottery[] secondaryIndex0;
        readonly Func<MasterLayoutLottery, int> secondaryIndex0Selector;

        public MasterLayoutLotteryTable(MasterLayoutLottery[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => (x.StageId, x.LayoutId);
            this.secondaryIndex0Selector = x => x.StageId;
            this.secondaryIndex0 = CloneAndSortBy(this.secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default);
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();

        public RangeView<MasterLayoutLottery> SortByStageId => new RangeView<MasterLayoutLottery>(secondaryIndex0, 0, secondaryIndex0.Length - 1, true);

        public MasterLayoutLottery FindByStageIdAndLayoutId((int StageId, int LayoutId) key)
        {
            return FindUniqueCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int StageId, int LayoutId)>.Default, key, true);
        }
        
        public bool TryFindByStageIdAndLayoutId((int StageId, int LayoutId) key, out MasterLayoutLottery result)
        {
            return TryFindUniqueCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int StageId, int LayoutId)>.Default, key, out result);
        }

        public MasterLayoutLottery FindClosestByStageIdAndLayoutId((int StageId, int LayoutId) key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int StageId, int LayoutId)>.Default, key, selectLower);
        }

        public RangeView<MasterLayoutLottery> FindRangeByStageIdAndLayoutId((int StageId, int LayoutId) min, (int StageId, int LayoutId) max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int StageId, int LayoutId)>.Default, min, max, ascendant);
        }

        public RangeView<MasterLayoutLottery> FindByStageId(int key)
        {
            return FindManyCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key);
        }

        public RangeView<MasterLayoutLottery> FindClosestByStageId(int key, bool selectLower = true)
        {
            return FindManyClosestCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<MasterLayoutLottery> FindRangeByStageId(int min, int max, bool ascendant = true)
        {
            return FindManyRangeCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "(StageId, LayoutId)", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(MasterLayoutLottery), typeof(MasterLayoutLotteryTable), "layout_lottery",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(MasterLayoutLottery).GetProperty("StageId")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterLayoutLottery).GetProperty("LayoutId")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterLayoutLottery).GetProperty("Weight")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterLayoutLottery).GetProperty("StageId"),
                        typeof(MasterLayoutLottery).GetProperty("LayoutId"),
                    }, true, true, System.Collections.Generic.Comparer<(int StageId, int LayoutId)>.Default),
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterLayoutLottery).GetProperty("StageId"),
                    }, false, false, System.Collections.Generic.Comparer<int>.Default),
                });
        }

#endif
    }
}