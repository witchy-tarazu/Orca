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
    public sealed class MasterPieceDescriptionFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Orca.MasterPieceDescription>
    {
        // PieceId
        private static global::System.ReadOnlySpan<byte> GetSpan_PieceId() => new byte[1 + 7] { 167, 80, 105, 101, 99, 101, 73, 100 };
        // Name
        private static global::System.ReadOnlySpan<byte> GetSpan_Name() => new byte[1 + 4] { 164, 78, 97, 109, 101 };
        // Description
        private static global::System.ReadOnlySpan<byte> GetSpan_Description() => new byte[1 + 11] { 171, 68, 101, 115, 99, 114, 105, 112, 116, 105, 111, 110 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Orca.MasterPieceDescription value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNil();
                return;
            }

            var formatterResolver = options.Resolver;
            writer.WriteMapHeader(3);
            writer.WriteRaw(GetSpan_PieceId());
            writer.Write(value.PieceId);
            writer.WriteRaw(GetSpan_Name());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<string>(formatterResolver).Serialize(ref writer, value.Name, options);
            writer.WriteRaw(GetSpan_Description());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<string>(formatterResolver).Serialize(ref writer, value.Description, options);
        }

        public global::Orca.MasterPieceDescription Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var formatterResolver = options.Resolver;
            var length = reader.ReadMapHeader();
            var __PieceId__ = default(int);
            var __Name__ = default(string);
            var __Description__ = default(string);

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
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 28228197479180624UL) { goto FAIL; }

                        __PieceId__ = reader.ReadInt32();
                        continue;
                    case 4:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 1701667150UL) { goto FAIL; }

                        __Name__ = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<string>(formatterResolver).Deserialize(ref reader, options);
                        continue;
                    case 11:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_Description().Slice(1))) { goto FAIL; }

                        __Description__ = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<string>(formatterResolver).Deserialize(ref reader, options);
                        continue;

                }
            }

            var ____result = new global::Orca.MasterPieceDescription(__PieceId__, __Name__, __Description__);
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
