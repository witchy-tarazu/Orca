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
    public sealed class MasterStageFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Orca.MasterStage>
    {
        // Id
        private static global::System.ReadOnlySpan<byte> GetSpan_Id() => new byte[1 + 2] { 162, 73, 100 };
        // PanelIndex
        private static global::System.ReadOnlySpan<byte> GetSpan_PanelIndex() => new byte[1 + 10] { 170, 80, 97, 110, 101, 108, 73, 110, 100, 101, 120 };
        // PanelType
        private static global::System.ReadOnlySpan<byte> GetSpan_PanelType() => new byte[1 + 9] { 169, 80, 97, 110, 101, 108, 84, 121, 112, 101 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Orca.MasterStage value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNil();
                return;
            }

            var formatterResolver = options.Resolver;
            writer.WriteMapHeader(3);
            writer.WriteRaw(GetSpan_Id());
            writer.Write(value.Id);
            writer.WriteRaw(GetSpan_PanelIndex());
            writer.Write(value.PanelIndex);
            writer.WriteRaw(GetSpan_PanelType());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.PanelType>(formatterResolver).Serialize(ref writer, value.PanelType, options);
        }

        public global::Orca.MasterStage Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var formatterResolver = options.Resolver;
            var length = reader.ReadMapHeader();
            var __Id__ = default(int);
            var __PanelIndex__ = default(int);
            var __PanelType__ = default(global::Orca.PanelType);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.Internal.CodeGenHelpers.ReadStringSpan(ref reader);
                switch (stringKey.Length)
                {
                    default:
                    FAIL:
                      reader.Skip();
                      continue;
                    case 2:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 25673UL) { goto FAIL; }

                        __Id__ = reader.ReadInt32();
                        continue;
                    case 10:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_PanelIndex().Slice(1))) { goto FAIL; }

                        __PanelIndex__ = reader.ReadInt32();
                        continue;
                    case 9:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_PanelType().Slice(1))) { goto FAIL; }

                        __PanelType__ = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Orca.PanelType>(formatterResolver).Deserialize(ref reader, options);
                        continue;

                }
            }

            var ____result = new global::Orca.MasterStage(__Id__, __PanelIndex__, __PanelType__);
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
