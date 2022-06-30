using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using System.Reflection;
using Vxtel.IoC.DI;
using Vxtel.IoC.Extension;

#region Builder

var builder = WebApplication.CreateBuilder(args);


IMetricsRoot Metrics = AppMetrics.CreateDefaultBuilder()
    .OutputMetrics.AsPrometheusPlainText()
    .OutputMetrics.AsPrometheusProtobuf()
    .Build();

builder.Host.ConfigureAppConfiguration((hostContext, config) =>
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        config.AddJsonFile($"{path}/appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureMetrics(Metrics)
    .UseMetrics(options =>
    {
        options.EndpointOptions = endpointsOptions =>
        {
            endpointsOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
            endpointsOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
            endpointsOptions.EnvironmentInfoEndpointEnabled = false;
        };
    })
    .UseMetricsEndpoints()
    .UseMetricsWebTracking();

#endregion

#region Services

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Customized Services
builder.Services.ConfigureServicesMetrics();
builder.Services.ConfigureServicesHealthCheck();
builder.Services.ConfigureServicesSwagger();
builder.Services.ConfigureServicesDatabase(configuration);

// Dependency Injection
builder.Services.ConfigureDependencies();

#endregion

#region App

var app = builder.Build();
var env = builder.Environment;

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Customized Apps
app.ConfigureMetrics();
app.ConfigureHealthCheck();
app.ConfigureSwagger(env);

app.Run();

#endregion