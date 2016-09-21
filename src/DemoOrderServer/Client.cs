using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Channels;
using Channels.BinaryProcessing;
using Channels.BinaryProcessing.Messages;
using Channels.Networking.Sockets;

namespace DemoOrderServer
{
    public class Client
    {
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, 5020);
        SocketConnection _client;
        public Client()
        {
        }

        public void Start()
        {
            _client = SocketConnection.ConnectAsync(endpoint).Result;
            Task.Run(() => ReadMessages(_client));
        }

        private async Task ReadMessages(IChannel channel)
        {
            try
            {
                int lastLength = 0;
                bool finished = false;
                while (!finished)
                {
                    var inputBuffer = await channel.Input.ReadAsync();
                    if (lastLength == inputBuffer.Length && channel.Input.Reading.IsCompleted)
                    {
                        throw new NotImplementedException("I need to handle this");
                    }
                    while (DeserializeMessage(ref inputBuffer)){ }
                    lastLength = inputBuffer.Length;
                    channel.Input.Advance(inputBuffer.Start, inputBuffer.End);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"exception {ex.ToString()}");
            }

        }

        private bool DeserializeMessage(ref ReadableBuffer inputBuffer)
        {
            return MessageFactory.HandleMessage(ref inputBuffer);
        }

        public async Task SendMessage<T>(T message) where T : IMessage
        {
            var buffer = _client.Output.Alloc(500);
            buffer.Ensure(4);
            var slice = buffer.Memory.Slice(0,2);
            buffer.WriteBigEndian((ushort)0);
            buffer.WriteBigEndian((ushort)message.MessageType);
            message.WriteMessage(ref buffer);
            var lengthWritten = buffer.AsReadableBuffer().Length;
            slice.WriteBigEndian((ushort)(lengthWritten - 4));

            await buffer.FlushAsync();
        }

    }
}
