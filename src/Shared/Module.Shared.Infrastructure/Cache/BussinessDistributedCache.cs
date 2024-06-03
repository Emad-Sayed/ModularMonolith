using Microsoft.Extensions.Caching.Distributed;
using Module.Shared.Application.Cache.Intefaces;
using System.Text.Json;

namespace Module.Shared.Infrastructure.Cache
{
    public class BussinessDistributedCache<T> : IBussinessDistributedCache<T> where T : class
    {
        public readonly IDistributedCache _distributedCache;

        public BussinessDistributedCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> GetItemAsync(string key)
        {
            var cachedData = await _distributedCache.GetStringAsync(key);
            if (string.IsNullOrEmpty(cachedData))
            {
                return null;
            }

            return JsonSerializer.Deserialize<T>(cachedData);
        }

        public async Task SetItemAsync(string key, T item)
        {
            var serializedData = JsonSerializer.Serialize(item);
            await _distributedCache.SetStringAsync(key, serializedData);
        }

    }
}
