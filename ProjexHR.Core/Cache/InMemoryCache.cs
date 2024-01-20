using Microsoft.Extensions.Caching.Memory;
using ProjexHR.Shared;

namespace ProjexHR.Core;

public class InMemoryCache
{
    private readonly IMemoryCache _cache;
    private readonly object _lock = new object();

    public InMemoryCache(IMemoryCache cache)
    {
        _cache = cache;
    }

    public BaseReturn<T> Get<T>(string cacheKey)
    {
        var baseObj = new BaseReturn<T>();
        try
        {
            baseObj.Data = _cache.Get<T>(cacheKey);
            baseObj.Success = true;
        }
        catch (Exception ex)
        {
            baseObj.Success = false;
            baseObj.Message = ex.Message;
        }
        return baseObj;
    }

    public void Set<T>(string cacheKey, T baseObj)
    {
        try
        {
            lock (_lock)
            {
                var allKeys = _cache.Get<List<string>>(CacheConfig.APPLICATION_KEY) ?? new List<string>();

                if (!allKeys.Contains(cacheKey))
                {
                    allKeys.Add(cacheKey);
                    _cache.Set(CacheConfig.APPLICATION_KEY, allKeys);
                }

                _cache.Remove(cacheKey);
                _cache.Set(cacheKey, baseObj);
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception
        }
    }

    public void Remove(string cacheKey)
    {
        try
        {
            _cache.Remove(cacheKey);
        }
        catch (Exception ex)
        {
            // Log or handle the exception
        }
    }

    public BaseReturn<bool> RemoveAll()
    {
        var baseObj = new BaseReturn<bool>();
        try
        {
            lock (_lock)
            {
                // Get all the keys used to store cached data.
                var allKeys = _cache.Get<List<string>>(CacheConfig.APPLICATION_KEY);

                // Delete all the cached keys
                if (allKeys != null)
                {
                    foreach (var key in allKeys)
                    {
                        _cache.Remove(key);
                    }

                    // Remove the application cache key as well
                    _cache.Remove(CacheConfig.APPLICATION_KEY);
                }
                baseObj.Success = true;
                baseObj.Data = true;
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            baseObj.Success = false;
            baseObj.Message = ex.Message;
        }
        return baseObj;
    }
}
