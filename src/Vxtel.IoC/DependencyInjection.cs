using Microsoft.Extensions.DependencyInjection;
using VxTel.Application.Service;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;
using VxTel.Infrastructure.Repository;

namespace Vxtel.IoC
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            // Repository
            services.AddTransient<ITarifaRepository, TarifaRepository>();

            // Service
            services.AddTransient<ITarifaService, TarifaService>();
        }
    }
}