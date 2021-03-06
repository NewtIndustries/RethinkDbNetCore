﻿using RethinkDb.Driver.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using RethinkDb.Driver;

namespace RethinkDbNetCore
{
    // https://www.c-sharpcorner.com/article/building-a-tcp-server-in-net-core-on-ubuntu/

    // netstat -nlp|grep 9000
    // https://docs.microsoft.com/en-us/dotnet/framework/network-programming/asynchronous-server-socket-example
    // https://github.com/Eastrall/Ether.Network
    public class RethinkServer
    {
        private Connection _connection;
        private TcpListener _tcpListener;
        private bool _active;
        public RethinkServer()
        {
            AppDomain.CurrentDomain.ProcessExit += (sender, args) => { _tcpListener?.Stop(); };
            
            _connection = RethinkDB.R.Connection()
                .Hostname("localhost")
                .Port(RethinkDBConstants.DefaultPort)
                .Timeout(60)
                .Connect();
            IPAddress address = IPAddress.Parse("0.0.0.0");
            _tcpListener = new TcpListener(address, 4242);
            _tcpListener.Start();
            _active = true;
            Listen().Wait();
            //var obj = new { X = 0, Y = 1, Z = 2 };
            //// var result = RethinkDB.R.Db("test").TableCreate("vectors").Run(_connection);
            //var result = RethinkDB.R.Db("test").Table("vectors").Insert(obj).Run(_connection);
            //Console.WriteLine(result.ToString());

            
        }

        private async Task Listen()
        {
            if (_tcpListener != null && _active)
            {
                while (true)
                {
                    Console.WriteLine("Waiting for client...");
                    var client = await _tcpListener.AcceptTcpClientAsync();
                    if (client != null)
                    { 
                        Console.WriteLine($"Client Connected From {client.Client.RemoteEndPoint.ToString()}");
                        var stream = client.GetStream();
                        var msg = System.Text.Encoding.UTF8.GetBytes("Hello World");
                        await stream.WriteAsync(msg, 0, msg.Length);
                    }
                }
            }
        }
    }
}
