using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using System.Runtime.CompilerServices;

namespace Dotnet.Core;

public static class Logger
{
    public static string UserName => "";

    public static ILogger InitialiseLogger()
    {
        var outputTemplate = "[{ThreadID} {Timestamp:HH:mm:ss}] [{Level}] [Username: {Username}] [Message: {Message}] [Method: {MemberName}] [FilePath: {FilePath}] [LineNumber: {LineNumber}] [SourceContext: {SourceContext}]{NewLine}";

        var logger = Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("System", LogEventLevel.Information)
            .Enrich.WithExceptionDetails()
            .Enrich.With(new ThreadIDEnricher())
            .Enrich.FromLogContext()
            .WriteTo.File("Logs/log.txt", LogEventLevel.Debug, outputTemplate, rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Logger.Here().Information("Initialized Logger");
        return logger;
    }

    public static ILogger Here(
        this ILogger logger,
        string sourceContext = "Web",
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0
      )
    {
        return logger
            .ForContext("MemberName", memberName)
            .ForContext("FilePath", sourceFilePath)
            .ForContext("LineNumber", sourceLineNumber)
            .ForContext("SourceContext", sourceContext)
            .ForContext("Username", GetUserName());
    }

    private static string GetUserName()
    {
        return UserName;
    }
}
