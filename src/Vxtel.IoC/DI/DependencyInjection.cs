using VxTel.Application.Service;
using VxTel.Application.UseCase;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;
using VxTel.Domain.Interface.UseCase;
using VxTel.Domain.Mapping;
using VxTel.Infrastructure.Repository;

namespace Vxtel.IoC.DI
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

            // UseCases
            services.AddTransient<IClienteUseCase, ClienteUseCase>();
            services.AddTransient<IConsumoUseCase, ConsumoUseCase>();

            // AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        }
    }
}