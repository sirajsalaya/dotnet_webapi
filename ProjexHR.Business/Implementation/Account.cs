using Microsoft.AspNetCore.Http;
using ProjexHR.Core;
using ProjexHR.Shared;
using Serilog;

namespace ProjexHR.Business;

public class Account
{
    public Account()
    {
    }

    public BaseReturn<bool> Login()
    {
        Log.Logger.Here().Information("Login started");
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