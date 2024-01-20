namespace Dotnet.Core;

public static class CacheConfig
{
    public const string APPLICATION_KEY = "dotnet_webapi_KEY";
    public static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromHours(24);
    public static readonly TimeSpan DefaultCacheDurationForUser = TimeSpan.FromMinutes(30);
}
