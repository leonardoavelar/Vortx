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
            services.AddTransient<IChamadaRepository, ChamadaRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IConsumoRepository, ConsumoRepository>();
            services.AddTransient<IContratoRepository, ContratoRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ITarifaRepository, TarifaRepository>();
            services.AddTransient<ITelefoneClienteRepository, TelefoneClienteRepository>();

            // Service
            services.AddTransient<IChamadaService, ChamadaService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IConsumoService, ConsumoService>();
            services.AddTransient<IContratoService, ContratoService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<ITarifaService, TarifaService>();
            services.AddTransient<ITelefoneClienteService, TelefoneClienteService>();
        }
    }
}