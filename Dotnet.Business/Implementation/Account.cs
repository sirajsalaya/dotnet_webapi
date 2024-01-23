using Microsoft.AspNetCore.Http;
using Dotnet.Contract;
using Dotnet.Core;
using Dotnet.Data;
using Dotnet.Shared;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Dotnet.Business;

public class Account : Base
{
    public Account(Config config) : base(config)
    {
        Log.Logger.Here().Information("Account controller started");
    }

    public BaseReturn<List<ELocationMaster>> Login()
    {
        Log.Logger.Here().Information("Login started");
        DotnetService<LocationMaster> _locationCtx = new DotnetService<LocationMaster>();
        BaseReturn<List<ELocationMaster>> baseObj = new();

        try
        {
            baseObj = GetSearchList<ELocationMaster>(
                new ELocationMaster(),
                x => !string.IsNullOrEmpty(x.LocationCd));
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