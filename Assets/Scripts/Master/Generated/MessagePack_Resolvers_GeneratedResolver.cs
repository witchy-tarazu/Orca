// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
#pragma warning disable CS1591 // document public APIs

#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Resolvers
{
    public class GeneratedResolver : global::MessagePack.IFormatterResolver
    {
        public static readonly global::MessagePack.IFormatterResolver Instance = new GeneratedResolver();

        private GeneratedResolver()
        {
        }

        public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            internal static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> Formatter;

            static FormatterCache()
            {
                var f = GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    Formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                }
            }
        }
    }

    internal static class GeneratedResolverGetFormatterHelper
    {
        private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, int> lookup;

        static GeneratedResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(9)
            {
                { typeof(global::Orca.CheckRange), 0 },
                { typeof(global::Orca.CheckSide), 1 },
                { typeof(global::Orca.CheckType), 2 },
                { typeof(global::Orca.ChildTriggerCondition), 3 },
                { typeof(global::Orca.InfluenceType), 4 },
                { typeof(global::Orca.MasterCard), 5 },
                { typeof(global::Orca.MasterCardDetail), 6 },
                { typeof(global::Orca.MasterInfluence), 7 },
                { typeof(global::Orca.MasterInfluenceRelation), 8 },
            };
        }

        internal static object GetFormatter(global::System.Type t)
        {
            int key;
            if (!lookup.TryGetValue(t, out key))
            {
                return null;
            }

            switch (key)
            {
                case 0: return new MessagePack.Formatters.Orca.CheckRangeFormatter();
                case 1: return new MessagePack.Formatters.Orca.CheckSideFormatter();
                case 2: return new MessagePack.Formatters.Orca.CheckTypeFormatter();
                case 3: return new MessagePack.Formatters.Orca.ChildTriggerConditionFormatter();
                case 4: return new MessagePack.Formatters.Orca.InfluenceTypeFormatter();
                case 5: return new MessagePack.Formatters.Orca.MasterCardFormatter();
                case 6: return new MessagePack.Formatters.Orca.MasterCardDetailFormatter();
                case 7: return new MessagePack.Formatters.Orca.MasterInfluenceFormatter();
                case 8: return new MessagePack.Formatters.Orca.MasterInfluenceRelationFormatter();
                default: return null;
            }
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1649 // File name should match first type name