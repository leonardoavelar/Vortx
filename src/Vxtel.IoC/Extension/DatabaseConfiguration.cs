using Microsoft.EntityFrameworkCore;
using VxTel.Infrastructure.Database;

namespace VxTel.Configuration.Extension
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureServicesDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = ConfigureConnectionString(configuration.GetConnectionString("MySql"));
            var server = ServerVersion.Create(new Version(), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
            //var server = ServerVersion.AutoDetect(connectionString);

            services.AddDbContextFactory<DatabaseContext>(options => options.UseMySql(connectionString, server), ServiceLifetime.Singleton);
        }

        private static string ConfigureConnectionString(string connectionString)
        {
            var result = connectionString.Replace("{MYSQL_SERVER}", Environment.GetEnvironmentVariable("MYSQL_SERVER"))
                                         .Replace("{MYSQL_PORT}", Environment.GetEnvironmentVariable("MYSQL_PORT"))
                                         .Replace("{MYSQL_DATABASE}", Environment.GetEnvironmentVariable("MYSQL_DATABASE"))
                                         .Replace("{MYSQL_USER}", Environment.GetEnvironmentVariable("MYSQL_USER"))
                                         .Replace("{MYSQL_PASSWORD}", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"));

            return result;
        }
    }
}
