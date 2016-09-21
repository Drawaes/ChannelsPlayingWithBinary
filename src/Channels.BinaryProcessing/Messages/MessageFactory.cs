using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Channels.BinaryProcessing.Messages
{
    public class MessageFactory
    {
        static int errorCount = 0;
        public static bool HandleMessage(ref ReadableBuffer reader)
        {
            if(reader.Length < 4)
                return false;

            var messageLength = reader.ReadBigEndian<ushort>();
            if(reader.Length < (messageLength + 4))
                return false;
            messageLength = reader.ReadBigEndian<ushort>();
            reader = reader.Slice(2);
            var messageType = (MessageTypes)reader.ReadBigEndian<ushort>();

            var messageBuff = reader.Slice(2,messageLength);

            switch(messageType)
            {
                case MessageTypes.LoginAck:
                    try
                    {
                        var md = new LoginResponse(ref messageBuff);
                        ///Fire off to low priority queue because it's not very important
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        Console.WriteLine("Number of errors" + errorCount);
                    }
                    break;
                case MessageTypes.SomeDataUpdate:
                    try
                    {
                        var md = new SomeDataUpdate(ref messageBuff);
                        ///Fire off to very important queue as its realtime
                    }
                    catch(Exception ex)
                    {
                        errorCount ++;
                        Console.WriteLine("Number of errors" + errorCount);
                    }
                    break;
            }

            
            return true;
        }
    }
}
