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
    public sealed class MasterEnemyBattleLayoutFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Orca.MasterEnemyBattleLayout>
    {
        // LayoutId
        private static global::System.ReadOnlySpan<byte> GetSpan_LayoutId() => new byte[1 + 8] { 168, 76, 97, 121, 111, 117, 116, 73, 100 };
        // RoleType
        private static global::System.ReadOnlySpan<byte> GetSpan_RoleType() => new byte[1 + 8] { 168, 82, 111, 108, 101, 84, 121, 112, 101 };
        // PositionIndex
        private static global::System.ReadOnlySpan<byte> GetSpan_PositionIndex() => new byte[1 + 13] { 173, 80, 111, 115, 105, 116, 105, 111, 110, 73, 110, 100, 101, 120 };
        // Number
        private static global::System.ReadOnlySpan<byte> GetSpan_Number() => new byte[1 + 6] { 166, 78, 117, 109, 98, 101, 114 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Orca.MasterEnemyBattleLayout value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNil();
                return;
            }

            var formatterResolver = options.Resolver;
            writer.WriteMapHeader(4);
            writer.WriteRaw(GetSpan_LayoutId());
            writer.Write(value.LayoutId);
            writer.WriteRaw(GetSpan_RoleType());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.RoleType>(formatterResolver).Serialize(ref writer, value.RoleType, options);
            writer.WriteRaw(GetSpan_PositionIndex());
            writer.Write(value.PositionIndex);
            writer.WriteRaw(GetSpan_Number());
            writer.Write(value.Number);
        }

        public global::Orca.MasterEnemyBattleLayout Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var formatterResolver = options.Resolver;
            var length = reader.ReadMapHeader();
            var __LayoutId__ = default(int);
            var __RoleType__ = default(global::Orca.RoleType);
            var __PositionIndex__ = default(int);
            var __Number__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.Internal.CodeGenHelpers.ReadStringSpan(ref reader);
                switch (stringKey.Length)
                {
                    default:
                    FAIL:
                      reader.Skip();
                      continue;
                    case 8:
                        switch (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey))
                        {
                            default: goto FAIL;
                            case 7226435124822892876UL:
                                __LayoutId__ = reader.ReadInt32();
                                continue;
                            case 7309475598608133970UL:
                                __RoleType__ = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.RoleType>(formatterResolver).Deserialize(ref reader, options);
                                continue;
                        }
                    case 13:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_PositionIndex().Slice(1))) { goto FAIL; }

                        __PositionIndex__ = reader.ReadInt32();
                        continue;
                    case 6:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 125779768603982UL) { goto FAIL; }

                        __Number__ = reader.ReadInt32();
                        continue;

                }
            }

            var ____result = new global::Orca.MasterEnemyBattleLayout(__LayoutId__, __RoleType__, __PositionIndex__, __Number__);
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