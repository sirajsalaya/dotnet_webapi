using Microsoft.AspNetCore.Http;
using ProjexHR.Contract;
using ProjexHR.Core;
using ProjexHR.Shared;
using Serilog;

namespace ProjexHR.Business;

public class Account
{
    public Account()
    {
    }

    public BaseReturn<ELogin> Login()
    {
        Log.Logger.Here().Information("Login started");
        BaseReturn<ELogin> baseObj = new();

        try
        {
            baseObj.Data = new ELogin
            {
                UserId = 10,
                Username = "JohnDoe"
            };
            baseObj.Success = true;
            baseObj.StatusCode = StatusCodes.Status200OK;
            baseObj.Message = "Login Successfull";
        }
        catch (Exception ex)
        {
            Log.Logger.Here().Error("Login error : {@ex}", ex);

            baseObj.Error = ex.Message;
            baseObj.Message = "Internal server error";
            baseObj.StatusCode = StatusCodes.Status500InternalServerError;
        }
        finally
        {
            Log.Logger.Here().Information("Login ended with success : {@ex}", baseObj.Success);
        }
        return baseObj;
    }
}