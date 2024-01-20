using Dotnet.Core;
using Dotnet.Shared;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Data;

public class DotnetService<T> : Repository<T> where T : class
{
    public DotnetService() : base(new DotnetContext(new DbContextOptionsBuilder<DotnetContext>().UseMySql(ConnectionConfig.ConnectionString, ServerVersion.Parse(ConnectionConfig.SQLVersion)).Options))
    {
    }

    public DotnetService(DbContext context) : base(context)
    {
    }

}
