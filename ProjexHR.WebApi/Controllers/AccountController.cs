using Microsoft.AspNetCore.Mvc;
using ProjexHR.Shared;

namespace ProjexHR.WebApi;

[Route("api/[controller]")]
public class AccountController : BaseController
{
    public AccountController(ILogger<BaseController> logger) : base(logger)
    {
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        _logger.LogInformation("Login started");
        BaseReturn<bool> baseObj = new();

        try
        {
            baseObj = new BaseReturn<bool>
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Message = "Login Successfull",
                Data = true,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError("Login error : {@ex}", ex);
        }
        finally
        {
            _logger.LogInformation("Login ended with success : {@ex}", baseObj.Success);
        }
        return Ok(baseObj);
    }

}
