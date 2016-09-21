using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Channels;
using Channels.BinaryProcessing;
using Channels.BinaryProcessing.Messages;

namespace Channels.BinaryProcessing.Messages
{
    public struct LoginResponse : IMessage
    {
        public LoginResponse(ref ReadableBuffer messageBuffer)
        {
            MessageId = messageBuffer.ReadBigEndian<int>();
            messageBuffer = messageBuffer.Slice(4);
        }

        public int MessageId { get;set;}
                
        public MessageTypes MessageType
        {
            get
            {
                return MessageTypes.LoginAck;
            }
        }

        public void WriteMessage(ref WritableBuffer buffer)
        {
            buffer.WriteBigEndian(MessageId);
        }

        
    }
}
