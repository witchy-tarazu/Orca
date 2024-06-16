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
   public sealed partial class MasterChildInfluenceTable : TableBase<MasterChildInfluence>, ITableUniqueValidate
   {
        public Func<MasterChildInfluence, int> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<MasterChildInfluence, int> primaryIndexSelector;

        readonly MasterChildInfluence[] secondaryIndex0;
        readonly Func<MasterChildInfluence, (ChildInfluenceParentType ParentType, int ParentId)> secondaryIndex0Selector;

        public MasterChildInfluenceTable(MasterChildInfluence[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.ChildId;
            this.secondaryIndex0Selector = x => (x.ParentType, x.ParentId);
            this.secondaryIndex0 = CloneAndSortBy(this.secondaryIndex0Selector, System.Collections.Generic.Comparer<(ChildInfluenceParentType ParentType, int ParentId)>.Default);
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();

        public RangeView<MasterChildInfluence> SortByParentTypeAndParentId => new RangeView<MasterChildInfluence>(secondaryIndex0, 0, secondaryIndex0.Length - 1, true);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public MasterChildInfluence FindByChildId(int key)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].ChildId;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { return data[mid]; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            return ThrowKeyNotFound(key);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public bool TryFindByChildId(int key, out MasterChildInfluence result)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].ChildId;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { result = data[mid]; return true; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            result = default;
            return false;
        }

        public MasterChildInfluence FindClosestByChildId(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<MasterChildInfluence> FindRangeByChildId(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }

        public RangeView<MasterChildInfluence> FindByParentTypeAndParentId((ChildInfluenceParentType ParentType, int ParentId) key)
        {
            return FindManyCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<(ChildInfluenceParentType ParentType, int ParentId)>.Default, key);
        }

        public RangeView<MasterChildInfluence> FindClosestByParentTypeAndParentId((ChildInfluenceParentType ParentType, int ParentId) key, bool selectLower = true)
        {
            return FindManyClosestCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<(ChildInfluenceParentType ParentType, int ParentId)>.Default, key, selectLower);
        }

        public RangeView<MasterChildInfluence> FindRangeByParentTypeAndParentId((ChildInfluenceParentType ParentType, int ParentId) min, (ChildInfluenceParentType ParentType, int ParentId) max, bool ascendant = true)
        {
            return FindManyRangeCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<(ChildInfluenceParentType ParentType, int ParentId)>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "ChildId", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(MasterChildInfluence), typeof(MasterChildInfluenceTable), "child_influence",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(MasterChildInfluence).GetProperty("ChildId")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterChildInfluence).GetProperty("ParentType")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterChildInfluence).GetProperty("ParentId")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterChildInfluence).GetProperty("TriggerCondition")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterChildInfluence).GetProperty("CheckSide")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterChildInfluence).GetProperty("InfluenceType")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterChildInfluence).GetProperty("BaseValue")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterChildInfluence).GetProperty("PropotionalValue")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterChildInfluence).GetProperty("ChildId"),
                    }, true, true, System.Collections.Generic.Comparer<int>.Default),
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterChildInfluence).GetProperty("ParentType"),
                        typeof(MasterChildInfluence).GetProperty("ParentId"),
                    }, false, false, System.Collections.Generic.Comparer<(ChildInfluenceParentType ParentType, int ParentId)>.Default),
                });
        }

#endif
    }
}