using StackExchange;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.CacheService
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _database;
        public CacheService(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }
        public Task<string> GetCacheAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task SetCacheAsync(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
