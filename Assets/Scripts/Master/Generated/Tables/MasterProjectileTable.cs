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
   public sealed partial class MasterProjectileTable : TableBase<MasterProjectile>, ITableUniqueValidate
   {
        public Func<MasterProjectile, int> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<MasterProjectile, int> primaryIndexSelector;


        public MasterProjectileTable(MasterProjectile[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.ProjectileId;
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public MasterProjectile FindByProjectileId(int key)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].ProjectileId;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { return data[mid]; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            return ThrowKeyNotFound(key);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public bool TryFindByProjectileId(int key, out MasterProjectile result)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].ProjectileId;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { result = data[mid]; return true; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            result = default;
            return false;
        }

        public MasterProjectile FindClosestByProjectileId(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<MasterProjectile> FindRangeByProjectileId(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "ProjectileId", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(MasterProjectile), typeof(MasterProjectileTable), "projectile",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(MasterProjectile).GetProperty("ProjectileId")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterProjectile).GetProperty("ProjectileType")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterProjectile).GetProperty("StartType")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterProjectile).GetProperty("Speed")),
                    new MasterMemory.Meta.MetaProperty(typeof(MasterProjectile).GetProperty("Distance")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(MasterProjectile).GetProperty("ProjectileId"),
                    }, true, true, System.Collections.Generic.Comparer<int>.Default),
                });
        }

#endif
    }
}