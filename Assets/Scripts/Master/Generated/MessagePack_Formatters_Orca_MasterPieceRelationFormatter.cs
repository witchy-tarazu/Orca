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
    public sealed class MasterPieceRelationFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Orca.MasterPieceRelation>
    {
        // PieceId
        private static global::System.ReadOnlySpan<byte> GetSpan_PieceId() => new byte[1 + 7] { 167, 80, 105, 101, 99, 101, 73, 100 };
        // Grade
        private static global::System.ReadOnlySpan<byte> GetSpan_Grade() => new byte[1 + 5] { 165, 71, 114, 97, 100, 101 };
        // CardId
        private static global::System.ReadOnlySpan<byte> GetSpan_CardId() => new byte[1 + 6] { 166, 67, 97, 114, 100, 73, 100 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Orca.MasterPieceRelation value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNil();
                return;
            }

            writer.WriteMapHeader(3);
            writer.WriteRaw(GetSpan_PieceId());
            writer.Write(value.PieceId);
            writer.WriteRaw(GetSpan_Grade());
            writer.Write(value.Grade);
            writer.WriteRaw(GetSpan_CardId());
            writer.Write(value.CardId);
        }

        public global::Orca.MasterPieceRelation Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var length = reader.ReadMapHeader();
            var __PieceId__ = default(int);
            var __Grade__ = default(int);
            var __CardId__ = default(int);

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
                    case 5:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 435475804743UL) { goto FAIL; }

                        __Grade__ = reader.ReadInt32();
                        continue;
                    case 6:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 110266380607811UL) { goto FAIL; }

                        __CardId__ = reader.ReadInt32();
                        continue;

                }
            }

            var ____result = new global::Orca.MasterPieceRelation(__PieceId__, __Grade__, __CardId__);
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
