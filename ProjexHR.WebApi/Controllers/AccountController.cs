using Microsoft.AspNetCore.Mvc;
using ProjexHR.Business;
using ProjexHR.Shared;

namespace ProjexHR.WebApi;

[Route("api/[controller]")]
public class AccountController : BaseController
{
    private readonly Account _account;
    public AccountController() : base()
    {
        _account = new();
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        BaseReturn<bool> baseObj = _account.Login();
        return StatusCode(baseObj.StatusCode > 0 ? baseObj.StatusCode : 200, baseObj);
    }

}
