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
	    var obj = new { X = 0, Y = 1, Z = 2 };
	    // var result = RethinkDB.R.Db("test").TableCreate("vectors").Run(_connection);
	    var result = RethinkDB.R.Db("test").Table("vectors").Insert(obj).Run(_connection);
	    Console.WriteLine(result.ToString());
        }
    }
}
