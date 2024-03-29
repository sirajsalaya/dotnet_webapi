using Serilog.Core;
using Serilog.Events;

namespace Dotnet.Core;

public class ThreadIDEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadID", Thread.CurrentThread.ManagedThreadId.ToString("D4")));
    }
}
