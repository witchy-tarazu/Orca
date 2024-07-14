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
   public sealed partial class MasterEnemyBattleLayoutTable : TableBase<MasterEnemyBattleLayout>, ITableUniqueValidate
   {
        public Func<MasterEnemyBattleLayout, (int LayoutId, RoleType RoleType, int PositionIndex)> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<MasterEnemyBattleLayout, (int LayoutId, RoleType RoleType, int PositionIndex)> primaryIndexSelector;

        readonly MasterEnemyBattleLayout[] secondaryIndex0;
        readonly Func<MasterEnemyBattleLayout, int> secondaryIndex0Selector;

        public MasterEnemyBattleLayoutTable(MasterEnemyBattleLayout[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => (x.LayoutId, x.RoleType, x.PositionIndex);
            this.secondaryIndex0Selector = x => x.LayoutId;
            this.secondaryIndex0 = CloneAndSortBy(this.secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default);
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();

        public RangeView<MasterEnemyBattleLayout> SortByLayoutId => new RangeView<MasterEnemyBattleLayout>(secondaryIndex0, 0, secondaryIndex0.Length - 1, true);

        public MasterEnemyBattleLayout FindByLayoutIdAndRoleTypeAndPositionIndex((int LayoutId, RoleType RoleType, int PositionIndex) key)
        {
            return FindUniqueCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default, key, true);
        }
        
        public bool TryFindByLayoutIdAndRoleTypeAndPositionIndex((int LayoutId, RoleType RoleType, int PositionIndex) key, out MasterEnemyBattleLayout result)
        {
            return TryFindUniqueCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default, key, out result);
        }

        public MasterEnemyBattleLayout FindClosestByLayoutIdAndRoleTypeAndPositionIndex((int LayoutId, RoleType RoleType, int PositionIndex) key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default, key, selectLower);
        }

        public RangeView<MasterEnemyBattleLayout> FindRangeByLayoutIdAndRoleTypeAndPositionIndex((int LayoutId, RoleType RoleType, int PositionIndex) min, (int LayoutId, RoleType RoleType, int PositionIndex) max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default, min, max, ascendant);
        }

        public RangeView<MasterEnemyBattleLayout> FindByLayoutId(int key)
        {
            return FindManyCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key);
        }

        public RangeView<MasterEnemyBattleLayout> FindClosestByLayoutId(int key, bool selectLower = true)
        {
            return FindManyClosestCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<MasterEnemyBattleLayout> FindRangeByLayoutId(int min, int max, bool ascendant = true)
        {
            return FindManyRangeCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "(LayoutId, RoleType, PositionIndex)", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(MasterEnemyBattleLayout), typeof(MasterEnemyBattleLayoutTable), "enemy_battle_layout",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(MasterEnemyBattleLayout).GetProperty("LayoutId")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterEnemyBattleLayout).GetProperty("RoleType")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterEnemyBattleLayout).GetProperty("PositionIndex")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterEnemyBattleLayout).GetProperty("Number")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterEnemyBattleLayout).GetProperty("LayoutId"),
                        typeof(MasterEnemyBattleLayout).GetProperty("RoleType"),
                        typeof(MasterEnemyBattleLayout).GetProperty("PositionIndex"),
                    }, true, true, System.Collections.Generic.Comparer<(int LayoutId, RoleType RoleType, int PositionIndex)>.Default),
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterEnemyBattleLayout).GetProperty("LayoutId"),
                    }, false, false, System.Collections.Generic.Comparer<int>.Default),
                });
        }

#endif
    }
}