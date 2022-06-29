namespace VxTel.Configuration.Extension
{
    public static class HealthCheckConfiguration
    {
        public static void ConfigureServicesHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
        }

        public static void ConfigureHealthCheck(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
