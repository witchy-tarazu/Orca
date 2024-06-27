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
    public sealed class MasterEnemyFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Orca.MasterEnemy>
    {
        // Id
        private static global::System.ReadOnlySpan<byte> GetSpan_Id() => new byte[1 + 2] { 162, 73, 100 };
        // PatternId
        private static global::System.ReadOnlySpan<byte> GetSpan_PatternId() => new byte[1 + 9] { 169, 80, 97, 116, 116, 101, 114, 110, 73, 100 };
        // MaxHp
        private static global::System.ReadOnlySpan<byte> GetSpan_MaxHp() => new byte[1 + 5] { 165, 77, 97, 120, 72, 112 };
        // Speed
        private static global::System.ReadOnlySpan<byte> GetSpan_Speed() => new byte[1 + 5] { 165, 83, 112, 101, 101, 100 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Orca.MasterEnemy value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNil();
                return;
            }

            writer.WriteMapHeader(4);
            writer.WriteRaw(GetSpan_Id());
            writer.Write(value.Id);
            writer.WriteRaw(GetSpan_PatternId());
            writer.Write(value.PatternId);
            writer.WriteRaw(GetSpan_MaxHp());
            writer.Write(value.MaxHp);
            writer.WriteRaw(GetSpan_Speed());
            writer.Write(value.Speed);
        }

        public global::Orca.MasterEnemy Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var length = reader.ReadMapHeader();
            var __Id__ = default(int);
            var __PatternId__ = default(int);
            var __MaxHp__ = default(int);
            var __Speed__ = default(int);

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
                    case 9:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_PatternId().Slice(1))) { goto FAIL; }

                        __PatternId__ = reader.ReadInt32();
                        continue;
                    case 5:
                        switch (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey))
                        {
                            default: goto FAIL;
                            case 482252185933UL:
                                __MaxHp__ = reader.ReadInt32();
                                continue;
                            case 431197876307UL:
                                __Speed__ = reader.ReadInt32();
                                continue;
                        }

                }
            }

            var ____result = new global::Orca.MasterEnemy(__Id__, __PatternId__, __MaxHp__, __Speed__);
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
