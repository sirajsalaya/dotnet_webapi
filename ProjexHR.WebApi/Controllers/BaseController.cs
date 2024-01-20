using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using ProjexHR.Business;
using ProjexHR.Core;
using ProjexHR.Shared;

namespace ProjexHR.WebApi;

[ApiController]
public class BaseController : ControllerBase
{
    protected readonly Config _config;

    public BaseController(IMemoryCache cache, IMapper mapper, IOptions<Config> config)
    {
        Base._cache = new CacheManager(cache);
        Base._mapper = mapper;
        _config = config.Value;
    }
}
