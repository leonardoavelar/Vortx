using Microsoft.EntityFrameworkCore;
using VxTel.Api.Infrastructure.Database;

namespace VxTel.Api.IoC.Extension
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureServicesDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = GetConnectionString(configuration);
            var server = ServerVersion.Create(new Version(), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);

            services.AddDbContextFactory<DatabaseContext>(options => options.UseMySql(connectionString, server), ServiceLifetime.Singleton);
        }

        public static string GetConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MySql");

            var result = connectionString.Replace("{MYSQL_SERVER}", Environment.GetEnvironmentVariable("MYSQL_SERVER"))
                                         .Replace("{MYSQL_PORT}", Environment.GetEnvironmentVariable("MYSQL_PORT"))
                                         .Replace("{MYSQL_DATABASE}", Environment.GetEnvironmentVariable("MYSQL_DATABASE"))
                                         .Replace("{MYSQL_USER}", Environment.GetEnvironmentVariable("MYSQL_USER"))
                                         .Replace("{MYSQL_PASSWORD}", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"));

            //var printConnect = Environment.GetEnvironmentVariable("PRINT_CONNECT");
            //if (!string.IsNullOrEmpty(printConnect) && printConnect.Contains("mysql"))
            //    Console.WriteLine(result);

            return result;
        }
    }
}
