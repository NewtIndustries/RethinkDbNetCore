using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace RethinkDbNetCore.Net
{
    public class ClientSession
    {
        private TcpClient _tcpClient;
        private NetworkStream _clientStream;

        public ClientSession(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
            _clientStream = tcpClient.GetStream();
            _clientStream.
        }
    }
}
