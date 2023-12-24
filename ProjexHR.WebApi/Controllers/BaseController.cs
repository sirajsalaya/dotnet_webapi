using Microsoft.AspNetCore.Mvc;

namespace ProjexHR.WebApi;

[ApiController]
public class BaseController : ControllerBase
{
    public readonly ILogger<BaseController> _logger;

    public BaseController(ILogger<BaseController> logger)
    {
        _logger = logger;
    }
}
