using ProjexHR.Core;
using ProjexHR.Shared;
using ProjexHR.Data.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace ProjexHR.Data;

public class ProjexHRService<T> : Repository<T> where T : class
{
    public ProjexHRService() : base(new ProjexHRContext(new DbContextOptionsBuilder<ProjexHRContext>().UseMySql(ConnectionConfig.ConnectionString, ServerVersion.AutoDetect(ConnectionConfig.ConnectionString)).Options))
    {
    }

    public ProjexHRService(DbContext context) : base(context)
    {
    }

}
