using System;
using System.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using WriteProcessorService.Interfaces;

namespace WriteProcessorService {
    public class CacheUpdater : ICacheUpdater {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection = new Lazy<ConnectionMultiplexer>(() => {
            var cacheConnection = ConfigurationManager.AppSettings["CacheConnection"];
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        private static ConnectionMultiplexer Connection => LazyConnection.Value;

        public void StoreObjectInCache(string key, object o)
        {
            var cache = Connection.GetDatabase();
            cache.StringSet(key, JsonConvert.SerializeObject(o));
        }
    }
}