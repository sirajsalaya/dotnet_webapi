using Serilog;
using ProjexHR.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Serilog Logger
// builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
ProjexHR.Core.Logger.InitialiseLogger();

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
ConnectionConfig.ConnectionString = config.CloudSQL.ConnectionString;
ConnectionConfig.ApplicationBasePath = config.ApplicationBasePath;

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
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjexHR WebApi");
        options.RoutePrefix = "";
    });
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseWhen(predicate => predicate.Request.Path.StartsWithSegments("/api"), configuration => configuration.UseMiddleware(typeof(ProjexHR.Core.SerilogMiddleware)));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
