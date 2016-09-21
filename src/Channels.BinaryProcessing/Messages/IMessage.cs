using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Channels;
using Channels.BinaryProcessing;
using Channels.BinaryProcessing.Messages;

namespace Channels.BinaryProcessing.Messages
{
    public interface IMessage
    {
        MessageTypes MessageType { get; }

        void WriteMessage(ref WritableBuffer buffer);
    }
}
