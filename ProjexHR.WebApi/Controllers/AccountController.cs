using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using ProjexHR.Business;
using ProjexHR.Contract;
using ProjexHR.Shared;

namespace ProjexHR.WebApi;

[Route("api/[controller]")]
public class AccountController : BaseController
{
    private readonly Account _account;
    public AccountController(IMemoryCache cache, IMapper mapper, IOptions<Config> config) : base(cache, mapper, config)
    {
        _account = new(_config);
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        BaseReturn<List<ELocationMaster>> baseObj = _account.Login();
        return StatusCode(baseObj.StatusCode > 0 ? baseObj.StatusCode : 200, baseObj);
    }

}
