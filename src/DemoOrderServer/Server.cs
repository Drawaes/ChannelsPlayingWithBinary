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
    public class Server
    {
        
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, 5020);
        SocketListener server;

        LoginResponse _loginResponse;
        

        public void Start()
        {
            _loginResponse = new LoginResponse();
            _loginResponse.MessageId = 1000;

           

            server = new SocketListener();
            server.OnConnection(UserConnected);
            server.Start(endpoint);
        }

        private async void UserConnected(IChannel channel)
        {
            try
            {
                int maxMessages = 1000000;
                int sentMessages = 0;
                while (sentMessages < maxMessages)
                {

                    
                    
                    sentMessages +=2;
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                channel?.Dispose();
            }
        }

        
    }


}
