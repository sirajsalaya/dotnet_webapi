using Serilog;
using Dotnet.Shared;
using Dotnet.Contract;
using System.Security.Authentication;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost
               .UseKestrel(options =>
               {
                   options.AddServerHeader = false;
                   options.ConfigureHttpsDefaults(s => s.SslProtocols = SslProtocols.Tls12);
               })
               .ConfigureLogging(cfg =>
               {
                   // Serilog Logger
                   // cfg.ClearProviders();
                   cfg.AddSerilog(Dotnet.Core.Logger.InitialiseLogger(), true);
               });

        // Add services to the container

        // Add configuration
        builder.Services.AddOptions();
        builder.Configuration
               .SetBasePath(builder.Environment.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);
        builder.Services.Configure<Config>(builder.Configuration.GetSection("Config"));
        var config = builder.Configuration.GetSection("Config").Get<Config>();

        // Database Connection string
        ConnectionConfig.Database = config.CloudSQL.Database;
        ConnectionConfig.SQLVersion = config.CloudSQL.SQLVersion;
        ConnectionConfig.ConnectionString = config.CloudSQL.ConnectionString;
        ConnectionConfig.ApplicationBasePath = config.ApplicationBasePath;

        // builder.Services.AddDbContext<DotnetContext>(
        //     options => options.UseMySql(ConnectionConfig.ConnectionString, ServerVersion.AutoDetect(ConnectionConfig.ConnectionString))
        //                       .EnableSensitiveDataLogging()
        //                       .EnableDetailedErrors());

        builder.Services.AddSingleton(AutoMapperConfig.Configure());
        builder.Services.AddMemoryCache();
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        // App builder
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Dotnet WebApi");
                options.RoutePrefix = "";
            });
            app.UseCors(builder
                => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
        }
        else
        {
            app.UseExceptionHandler("/error");
        }

        app.UseHsts();

        app.UseWhen(predicate
            => predicate.Request.Path.StartsWithSegments("/api"),
               configuration
                => configuration.UseMiddleware<Dotnet.Core.SerilogMiddleware>());

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}