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
   public sealed partial class MasterEnemyTable : TableBase<MasterEnemy>, ITableUniqueValidate
   {
        public Func<MasterEnemy, int> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<MasterEnemy, int> primaryIndexSelector;

        readonly MasterEnemy[] secondaryIndex0;
        readonly Func<MasterEnemy, (RoleType RoleType, int Level)> secondaryIndex0Selector;

        public MasterEnemyTable(MasterEnemy[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.Id;
            this.secondaryIndex0Selector = x => (x.RoleType, x.Level);
            this.secondaryIndex0 = CloneAndSortBy(this.secondaryIndex0Selector, System.Collections.Generic.Comparer<(RoleType RoleType, int Level)>.Default);
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();

        public RangeView<MasterEnemy> SortByRoleTypeAndLevel => new RangeView<MasterEnemy>(secondaryIndex0, 0, secondaryIndex0.Length - 1, true);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public MasterEnemy FindById(int key)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].Id;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { return data[mid]; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            return ThrowKeyNotFound(key);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public bool TryFindById(int key, out MasterEnemy result)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].Id;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { result = data[mid]; return true; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            result = default;
            return false;
        }

        public MasterEnemy FindClosestById(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<MasterEnemy> FindRangeById(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }

        public RangeView<MasterEnemy> FindByRoleTypeAndLevel((RoleType RoleType, int Level) key)
        {
            return FindManyCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<(RoleType RoleType, int Level)>.Default, key);
        }

        public RangeView<MasterEnemy> FindClosestByRoleTypeAndLevel((RoleType RoleType, int Level) key, bool selectLower = true)
        {
            return FindManyClosestCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<(RoleType RoleType, int Level)>.Default, key, selectLower);
        }

        public RangeView<MasterEnemy> FindRangeByRoleTypeAndLevel((RoleType RoleType, int Level) min, (RoleType RoleType, int Level) max, bool ascendant = true)
        {
            return FindManyRangeCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<(RoleType RoleType, int Level)>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "Id", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(MasterEnemy), typeof(MasterEnemyTable), "enemy",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(MasterEnemy).GetProperty("Id")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterEnemy).GetProperty("RoleType")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterEnemy).GetProperty("Level")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterEnemy).GetProperty("PatternId")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterEnemy).GetProperty("MaxHp")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterEnemy).GetProperty("Speed")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterEnemy).GetProperty("Id"),
                    }, true, true, System.Collections.Generic.Comparer<int>.Default),
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterEnemy).GetProperty("RoleType"),
                        typeof(MasterEnemy).GetProperty("Level"),
                    }, false, false, System.Collections.Generic.Comparer<(RoleType RoleType, int Level)>.Default),
                });
        }

#endif
    }
}