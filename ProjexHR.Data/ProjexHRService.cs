using ProjexHR.Core;
using ProjexHR.Shared;
using Microsoft.EntityFrameworkCore;

namespace ProjexHR.Data;

public class ProjexHRService<T> : Repository<T> where T : class
{
    public ProjexHRService() : base(new ProjexHRContext(new DbContextOptionsBuilder<ProjexHRContext>().UseMySql(ConnectionConfig.ConnectionString, ServerVersion.Parse(ConnectionConfig.SQLVersion)).Options))
    {
    }

    public ProjexHRService(DbContext context) : base(context)
    {
    }

}
