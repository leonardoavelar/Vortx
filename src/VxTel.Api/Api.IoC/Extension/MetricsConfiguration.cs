using Microsoft.AspNetCore.Mvc;

namespace VxTel.Api.IoC.Extension
{
    public static class MetricsConfiguration
    {
        public static void ConfigureServicesMetrics(this IServiceCollection services)
        {
            services.AddMetrics();
            services.AddMetricsTrackingMiddleware();
            services.AddMetricsEndpoints();
            services.AddMvcCore()
                .AddMetricsCore();
        }

        public static void ConfigureMetrics(this IApplicationBuilder app)
        {
            app.UseMetricsAllEndpoints();
            app.UseMetricsActiveRequestMiddleware();
            app.UseMetricsErrorTrackingMiddleware();
            app.UseMetricsPostAndPutSizeTrackingMiddleware();
            app.UseMetricsRequestTrackingMiddleware();
            app.UseMetricsOAuth2TrackingMiddleware();
            app.UseMetricsApdexTrackingMiddleware();
            app.UseMetricsEndpoint();
            app.UseMetricsTextEndpoint();
            app.UseEnvInfoEndpoint();
        }
    }
}
