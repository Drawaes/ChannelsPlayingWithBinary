using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Channels.Text.Primitives;

namespace Channels.BinaryProcessing.Messages
{
    public struct SomeDataUpdate: IMessage
    {
        public SomeDataUpdate(ref ReadableBuffer buffer)
        {
            Bid1 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Bid2 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Bid3 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Bid4 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Ask1 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Ask2 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Ask3 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Ask4 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Size1 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Size2 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Size3 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            Size4 = buffer.ReadBigEndian<int>();
            buffer = buffer.Slice(4);
            ReadableBuffer stringBuffer;
            ReadCursor endCursor;
            buffer.TrySliceTo(0x00, out stringBuffer, out endCursor);

            SecurityCode = stringBuffer.GetAsciiString();
            buffer = buffer.Slice(endCursor).Slice(1);
        }

        public MessageTypes MessageType
        {
            get
            {
                return MessageTypes.SomeDataUpdate;
            }
        }

        public int Bid1;
        public int Bid2;
        public int Bid3;
        public int Bid4;
        public int Ask1;
        public int Ask2;
        public int Ask3;
        public int Ask4;
        public int Size1;
        public int Size2;
        public int Size3;
        public int Size4;

        public string SecurityCode;

        public void WriteMessage(ref WritableBuffer buffer)
        {
            buffer.WriteBigEndian(Bid1);
            buffer.WriteBigEndian(Bid2);
            buffer.WriteBigEndian(Bid3);
            buffer.WriteBigEndian(Bid4);
            buffer.WriteBigEndian(Ask1);
            buffer.WriteBigEndian(Ask2);
            buffer.WriteBigEndian(Ask3);
            buffer.WriteBigEndian(Ask4);
            buffer.WriteBigEndian(Size1);
            buffer.WriteBigEndian(Size2);
            buffer.WriteBigEndian(Size3);
            buffer.WriteBigEndian(Size4);
            buffer.WriteAsciiString(SecurityCode);
            buffer.WriteLittleEndian(0x00);
        }
    }
}
