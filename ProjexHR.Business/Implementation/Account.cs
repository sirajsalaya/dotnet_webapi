using Microsoft.AspNetCore.Http;
using ProjexHR.Contract;
using ProjexHR.Core;
using ProjexHR.Data;
using ProjexHR.Shared;
using Serilog;

namespace ProjexHR.Business;

public class Account : Base
{
    public Account(Config config) : base(config)
    {
        Log.Logger.Here().Information("Account controller started");
    }

    public BaseReturn<List<ELocationMaster>> Login()
    {
        Log.Logger.Here().Information("Login started");
        ProjexHRService<LocationMaster> _locationCtx = new ProjexHRService<LocationMaster>();
        BaseReturn<List<ELocationMaster>> baseObj = new();

        try
        {
            baseObj.Data = _locationCtx
                .GetIQueryable()
                .Select(x => new ELocationMaster
                {
                    LocationId = x.LocationId,
                    LocationCd = x.LocationCd,
                    LocationName = x.LocationName,
                    IsDelete = x.IsDelete,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedOn = x.ModifiedOn,
                }).ToList();

            baseObj.ItemCount = baseObj.Data.Count;
            baseObj.Success = true;
            baseObj.StatusCode = StatusCodes.Status200OK;
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