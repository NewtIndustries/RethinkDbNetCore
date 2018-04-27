using RethinkDb.Driver.Net;
using System;
using System.Collections.Generic;
using System.Text;
using RethinkDb.Driver;

namespace RethinkDbNetCore
{
    public class RethinkServer
    {
        private Connection _connection;

        public RethinkServer()
        {
            _connection = RethinkDB.R.Connection()
                .Hostname("localhost")
                .Port(RethinkDBConstants.DefaultPort)
                .Timeout(60)
                .Connect();
        }
    }
}
