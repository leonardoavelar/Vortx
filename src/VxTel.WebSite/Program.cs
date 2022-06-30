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

builder.Services.AddRazorPages();

#endregion

#region Services

var configuration = builder.Configuration;

// Customized Services
builder.Services.ConfigureServicesMetrics();
builder.Services.ConfigureServicesHealthCheck();
builder.Services.ConfigureServicesDatabase(configuration);

// Dependency Injection
builder.Services.ConfigureDependencies();

#endregion


#region App 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

// Customized Apps
app.ConfigureMetrics();
app.ConfigureHealthCheck();

app.Run();

#endregion