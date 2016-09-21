using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Channels.BinaryProcessing.Messages
{
    public enum MessageTypes
    {
        Login,
        LoginAck,
        LoginNack,
        SomeDataUpdate,
        ServerEvent
    }
}
