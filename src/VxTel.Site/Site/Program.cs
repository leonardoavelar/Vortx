using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using System.Reflection;
using VxTel.Site.IoC.Extension;

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
builder.Services.AddControllersWithViews();

// Customized Services
builder.Services.ConfigureServicesMetrics();
builder.Services.ConfigureServicesHealthCheck();
builder.Services.ConfigureServicesRefit(configuration);

#endregion

#region App

var app = builder.Build();
var env = builder.Environment;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Customized Apps
app.ConfigureMetrics();
app.ConfigureHealthCheck();

app.Run();

#endregion