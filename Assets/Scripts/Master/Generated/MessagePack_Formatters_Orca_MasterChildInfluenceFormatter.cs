// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
#pragma warning disable CS1591 // document public APIs

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.Orca
{
    public sealed class MasterChildInfluenceFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Orca.MasterChildInfluence>
    {
        // ChildId
        private static global::System.ReadOnlySpan<byte> GetSpan_ChildId() => new byte[1 + 7] { 167, 67, 104, 105, 108, 100, 73, 100 };
        // ParentType
        private static global::System.ReadOnlySpan<byte> GetSpan_ParentType() => new byte[1 + 10] { 170, 80, 97, 114, 101, 110, 116, 84, 121, 112, 101 };
        // ParentId
        private static global::System.ReadOnlySpan<byte> GetSpan_ParentId() => new byte[1 + 8] { 168, 80, 97, 114, 101, 110, 116, 73, 100 };
        // TriggerCondition
        private static global::System.ReadOnlySpan<byte> GetSpan_TriggerCondition() => new byte[1 + 16] { 176, 84, 114, 105, 103, 103, 101, 114, 67, 111, 110, 100, 105, 116, 105, 111, 110 };
        // CheckSide
        private static global::System.ReadOnlySpan<byte> GetSpan_CheckSide() => new byte[1 + 9] { 169, 67, 104, 101, 99, 107, 83, 105, 100, 101 };
        // InfluenceType
        private static global::System.ReadOnlySpan<byte> GetSpan_InfluenceType() => new byte[1 + 13] { 173, 73, 110, 102, 108, 117, 101, 110, 99, 101, 84, 121, 112, 101 };
        // BaseValue
        private static global::System.ReadOnlySpan<byte> GetSpan_BaseValue() => new byte[1 + 9] { 169, 66, 97, 115, 101, 86, 97, 108, 117, 101 };
        // PropotionalValue
        private static global::System.ReadOnlySpan<byte> GetSpan_PropotionalValue() => new byte[1 + 16] { 176, 80, 114, 111, 112, 111, 116, 105, 111, 110, 97, 108, 86, 97, 108, 117, 101 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Orca.MasterChildInfluence value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNil();
                return;
            }

            var formatterResolver = options.Resolver;
            writer.WriteMapHeader(8);
            writer.WriteRaw(GetSpan_ChildId());
            writer.Write(value.ChildId);
            writer.WriteRaw(GetSpan_ParentType());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.ChildInfluenceParentType>(formatterResolver).Serialize(ref writer, value.ParentType, options);
            writer.WriteRaw(GetSpan_ParentId());
            writer.Write(value.ParentId);
            writer.WriteRaw(GetSpan_TriggerCondition());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.ChildTriggerCondition>(formatterResolver).Serialize(ref writer, value.TriggerCondition, options);
            writer.WriteRaw(GetSpan_CheckSide());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.InfluenceCheckSide>(formatterResolver).Serialize(ref writer, value.CheckSide, options);
            writer.WriteRaw(GetSpan_InfluenceType());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.InfluenceType>(formatterResolver).Serialize(ref writer, value.InfluenceType, options);
            writer.WriteRaw(GetSpan_BaseValue());
            writer.Write(value.BaseValue);
            writer.WriteRaw(GetSpan_PropotionalValue());
            writer.Write(value.PropotionalValue);
        }

        public global::Orca.MasterChildInfluence Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var formatterResolver = options.Resolver;
            var length = reader.ReadMapHeader();
            var __ChildId__ = default(int);
            var __ParentType__ = default(global::Orca.ChildInfluenceParentType);
            var __ParentId__ = default(int);
            var __TriggerCondition__ = default(global::Orca.ChildTriggerCondition);
            var __CheckSide__ = default(global::Orca.InfluenceCheckSide);
            var __InfluenceType__ = default(global::Orca.InfluenceType);
            var __BaseValue__ = default(int);
            var __PropotionalValue__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.Internal.CodeGenHelpers.ReadStringSpan(ref reader);
                switch (stringKey.Length)
                {
                    default:
                    FAIL:
                      reader.Skip();
                      continue;
                    case 7:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 28228193335470147UL) { goto FAIL; }

                        __ChildId__ = reader.ReadInt32();
                        continue;
                    case 10:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_ParentType().Slice(1))) { goto FAIL; }

                        __ParentType__ = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.ChildInfluenceParentType>(formatterResolver).Deserialize(ref reader, options);
                        continue;
                    case 8:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 7226435094589890896UL) { goto FAIL; }

                        __ParentId__ = reader.ReadInt32();
                        continue;
                    case 16:
                        switch (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey))
                        {
                            default: goto FAIL;
                            case 4860058442677187156UL:
                                if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 7957695015292268143UL) { goto FAIL; }

                                __TriggerCondition__ = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.ChildTriggerCondition>(formatterResolver).Deserialize(ref reader, options);
                                continue;

                            case 8028075832741163600UL:
                                if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 7310868735423439214UL) { goto FAIL; }

                                __PropotionalValue__ = reader.ReadInt32();
                                continue;

                        }
                    case 9:
                        switch (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey))
                        {
                            default: goto FAIL;
                            case 7235405997041608771UL:
                                if (stringKey[0] != 101) { goto FAIL; }

                                __CheckSide__ = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.InfluenceCheckSide>(formatterResolver).Deserialize(ref reader, options);
                                continue;

                            case 8461244823619461442UL:
                                if (stringKey[0] != 101) { goto FAIL; }

                                __BaseValue__ = reader.ReadInt32();
                                continue;

                        }
                    case 13:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_InfluenceType().Slice(1))) { goto FAIL; }

                        __InfluenceType__ = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.InfluenceType>(formatterResolver).Deserialize(ref reader, options);
                        continue;

                }
            }

            var ____result = new global::Orca.MasterChildInfluence(__ChildId__, __ParentType__, __ParentId__, __TriggerCondition__, __CheckSide__, __InfluenceType__, __BaseValue__, __PropotionalValue__);
            reader.Depth--;
            return ____result;
        }
    }

}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name