using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ProjexHR.WebApi;

[Route("api/[controller]")]
public class AccountController : BaseController
{
    public AccountController() : base()
    {
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        Log.Logger.Information("Login started");
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
            Log.Logger.Error("Login error : {@ex}", ex);
        }
        finally
        {
            Log.Logger.Information("Login ended with success : {@ex}", baseObj.Success);
        }
        return Ok(baseObj);
    }

}
