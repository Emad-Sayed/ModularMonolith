using Microsoft.Extensions.Caching.Distributed;
using Module.Shared.Application.Cache.Intefaces;
using System.Text.Json;

namespace Module.Shared.Infrastructure.Cache
{
    public class BussinessDistributedCache : IBussinessDistributedCache
    {
        public readonly IDistributedCache _distributedCache;

        public BussinessDistributedCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            var cachedData = await _distributedCache.GetStringAsync(key);
            if (string.IsNullOrEmpty(cachedData))
                return default;
            return JsonSerializer.Deserialize<T>(cachedData);
        }

        public async Task SetItemAsync<T>(string key, T item)
        {
            var serializedData = JsonSerializer.Serialize(item);
            await _distributedCache.SetStringAsync(key, serializedData);
        }

    }
}
