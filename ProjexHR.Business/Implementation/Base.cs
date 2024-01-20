using System.Linq.Expressions;
using AutoMapper;
using ProjexHR.Core;
using ProjexHR.Data;
using ProjexHR.Shared;
using Serilog;

namespace ProjexHR.Business;

public class Base
{
    public static ICacheManager _cache;
    public static IMapper _mapper;
    protected readonly Config _config;

    public Base(Config config)
    {
        _config = config;
    }

    public BaseReturn<List<T>> GetSearchList<T>(T request, Func<T, bool> exp, string name = "")
    {
        Log.Logger.Here().Information("GetSearchList started");
        var baseObj = new BaseReturn<List<T>>();

        try
        {
            var result = getdbList<T>(request, name);
            result.Data = result.Data ?? new List<T>();
            baseObj.Data = exp != null ? result.Data.Where(exp).ToList() : result.Data;
            baseObj.ItemCount = baseObj.Data.Count();
            baseObj.Success = true;
        }
        catch (Exception ex)
        {
            baseObj.Success = false;
            Log.Logger.Here().Error("Error {@ex}", ex);
        }
        finally
        {
            Log.Logger.Here().Information("Ended");
        }
        return baseObj;
    }

    public BaseReturn<List<T>> getdbList<T>(T request, string name = "")
    {
        BaseReturn<List<T>> results = new BaseReturn<List<T>>();
        string typeName = name != "" ? name : request.GetType().Name;

        switch (typeName)
        {
            case "ELocationMaster":
                results = GetMasterList<T, LocationMaster>((m => m.IsActive == true && m.IsDelete == false), "db_" + typeName);
                break;
                // Add more cases as needed
        }
        return results;
    }

    public BaseReturn<List<T>> GetMasterList<T, D>(Expression<Func<D, bool>> exp, string cachekey = "") where D : class
    {
        Log.Logger.Here().Information("For {@cachekey}, started", cachekey);
        BaseReturn<List<T>> baseObj = new BaseReturn<List<T>>();
        try
        {
            baseObj = _cache.Get<List<T>>(cachekey);
            if (baseObj.Success == false || baseObj.Data == null || baseObj.Data.Count == 0)
            {
                var data = exp == null ? new ProjexHRService<D>().GetIQueryable().ToList() : new ProjexHRService<D>().GetIQueryable(exp).ToList();
                baseObj = new BaseReturn<List<T>>();
                baseObj.Data = _mapper.Map<List<T>>(data);
                _cache.Set<List<T>>(cachekey, baseObj.Data);
            }
            baseObj.ItemCount = baseObj.Data.Count;
            baseObj.Success = true;
        }
        catch (Exception ex)
        {
            Log.Logger.Here().Error("For {@cachekey}, Error {@ex}", cachekey, ex);
            baseObj.Success = false;
            baseObj.Message = ex.Message;
        }
        finally
        {
            Log.Logger.Here().Information("For {@cachekey}, ended", cachekey);
        }
        return baseObj;
    }

}