
using Microsoft.Extensions.Caching.Memory;
using ProjexHR.Shared;

namespace ProjexHR.Core;

public class CacheManager : ICacheManager
{
    private readonly InMemoryCache _memCache;

    public CacheManager(IMemoryCache cache)
    {
        _memCache = new InMemoryCache(cache);
    }

    public BaseReturn<T> Get<T>(string cacheKey)
    {
        return _memCache.Get<T>(cacheKey);
    }

    public void Set<T>(string cacheKey, T baseObj)
    {
        _memCache.Set(cacheKey, baseObj);
    }

    public void Remove(string cacheKey)
    {
        _memCache.Remove(cacheKey);
    }

    public BaseReturn<bool> RemoveAll()
    {
        return _memCache.RemoveAll();
    }
}
