// <auto-generated />
#pragma warning disable CS0105
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using Orca;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using Orca.Tables;

namespace Orca
{
   public sealed class DatabaseBuilder : DatabaseBuilderBase
   {
        public DatabaseBuilder() : this(null) { }
        public DatabaseBuilder(MessagePack.IFormatterResolver resolver) : base(resolver) { }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterCard> dataSource)
        {
            AppendCore(dataSource, x => x.CardId, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterCardDetail> dataSource)
        {
            AppendCore(dataSource, x => (x.CardId, x.InfluenceId), System.Collections.Generic.Comparer<(int CardId, int InfluenceId)>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterInfluence> dataSource)
        {
            AppendCore(dataSource, x => x.InfluenceId, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<MasterInfluenceRelation> dataSource)
        {
            AppendCore(dataSource, x => (x.ParentId, x.ChildId), System.Collections.Generic.Comparer<(int ParentId, int ChildId)>.Default);
            return this;
        }

    }
}