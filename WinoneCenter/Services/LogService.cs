using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinoneCenter.Models;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace WinoneCenter.Services
{
    public class LogService
    {
        private readonly IMongoCollection<Log> _log;

        public LogService(IDBSettings settings)
        {
            var client = new MongoClient(settings.ConnStr);
            var db = client.GetDatabase(settings.DBName);
            _log = db.GetCollection<Log>("Log");
        }

        public IQueryable<Log> GetOneByFunction(string function)
        {
            return _log.AsQueryable<Log>().Where(x => x.Function == function);
        }

        public Log GetOneById(string id)
        {
            return _log.AsQueryable<Log>().Where(x => x.Id == id).First();
        }

        public void InsertOne(Log log)
        {
            log.LastModified = DateTime.Now;
            _log.InsertOne(log);
        }

        public void UpdateOne(Log log)
        {
            var builder = Builders<Log>.Filter;
            var filter = builder.Eq("Id", log.Id);

            var update = Builders<Log>.Update.Set("Function", log.Function)
                                             .Set("Description", log.Description)
                                             .Set("JsonReturn", log.ReturnMsg)
                                             .Set("DataStatus", log.DataStatus)
                                             .CurrentDate("LastModified");
            _log.UpdateOne(filter, update);
        }

    }
}
