
using RethinkDb.Driver;
using RethinkDb.Driver.Net;

namespace RethinkDbNetCore
{
    public class RethinkClient
    {
        private static RethinkDB _r = RethinkDB.R;
        private Connection _connection;
        public RethinkClient()
        {
            _connection = _r.Connection()
                .Hostname("linuxdev.newtindustries.com")
                .Port(RethinkDBConstants.DefaultPort)
                .Timeout(60)
                .Connect();
            var result = _r.Db("test").Table("testTable").Insert(new {X = 0, Y = 0, Z = 0}).Run(_connection);
            result.Dump();
        }
    }
}