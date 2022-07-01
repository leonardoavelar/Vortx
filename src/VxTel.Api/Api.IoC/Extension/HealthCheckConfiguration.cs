namespace VxTel.Api.IoC.Extension
{
    public static class HealthCheckConfiguration
    {
        public static void ConfigureServicesHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = DatabaseConfiguration.GetConnectionString(configuration);
            
            services.AddHealthChecks()
                .AddMySql(connectionString);
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
