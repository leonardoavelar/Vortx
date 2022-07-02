using VxTel.Api.Application.Service;
using VxTel.Api.Application.UseCase;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Domain.Interface.Service;
using VxTel.Api.Domain.Interface.UseCase;
using VxTel.Api.Domain.Mapping;
using VxTel.Api.Infrastructure.Repository;

namespace VxTel.Api.IoC.DI
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

            // Service
            services.AddTransient<IChamadaService, ChamadaService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IConsumoService, ConsumoService>();
            services.AddTransient<IContratoService, ContratoService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<ITarifaService, TarifaService>();

            // UseCases
            services.AddTransient<IClienteUseCase, ClienteUseCase>();
            services.AddTransient<IConsumoUseCase, ConsumoUseCase>();

            // AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        }
    }
}