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
    public sealed class MasterCardFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Orca.MasterCard>
    {
        // CardId
        private static global::System.ReadOnlySpan<byte> GetSpan_CardId() => new byte[1 + 6] { 166, 67, 97, 114, 100, 73, 100 };
        // Grade
        private static global::System.ReadOnlySpan<byte> GetSpan_Grade() => new byte[1 + 5] { 165, 71, 114, 97, 100, 101 };
        // FinishFrame
        private static global::System.ReadOnlySpan<byte> GetSpan_FinishFrame() => new byte[1 + 11] { 171, 70, 105, 110, 105, 115, 104, 70, 114, 97, 109, 101 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Orca.MasterCard value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNil();
                return;
            }

            writer.WriteMapHeader(3);
            writer.WriteRaw(GetSpan_CardId());
            writer.Write(value.CardId);
            writer.WriteRaw(GetSpan_Grade());
            writer.Write(value.Grade);
            writer.WriteRaw(GetSpan_FinishFrame());
            writer.Write(value.FinishFrame);
        }

        public global::Orca.MasterCard Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var length = reader.ReadMapHeader();
            var __CardId__ = default(int);
            var __Grade__ = default(int);
            var __FinishFrame__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.Internal.CodeGenHelpers.ReadStringSpan(ref reader);
                switch (stringKey.Length)
                {
                    default:
                    FAIL:
                      reader.Skip();
                      continue;
                    case 6:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 110266380607811UL) { goto FAIL; }

                        __CardId__ = reader.ReadInt32();
                        continue;
                    case 5:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 435475804743UL) { goto FAIL; }

                        __Grade__ = reader.ReadInt32();
                        continue;
                    case 11:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_FinishFrame().Slice(1))) { goto FAIL; }

                        __FinishFrame__ = reader.ReadInt32();
                        continue;

                }
            }

            var ____result = new global::Orca.MasterCard(__CardId__, __Grade__, __FinishFrame__);
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
