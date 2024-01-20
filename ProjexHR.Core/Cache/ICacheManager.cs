
using ProjexHR.Shared;

namespace ProjexHR.Core;

public interface ICacheManager
{
    BaseReturn<T> Get<T>(string cacheKey);
    void Set<T>(string cacheKey, T baseObj);
    void Remove(string cacheKey);
    BaseReturn<bool> RemoveAll();
}
