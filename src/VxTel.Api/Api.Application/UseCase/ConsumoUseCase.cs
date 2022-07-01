using VxTel.Api.Domain.Interface.Service;
using VxTel.Api.Domain.Interface.UseCase;

namespace VxTel.Api.Application.UseCase
{
    public class ConsumoUseCase : IConsumoUseCase
    {
        private readonly IClienteService _clienteService;
        private readonly IConsumoService _consumoService;

        public ConsumoUseCase(IClienteService clienteService, IConsumoService consumoService)
        {
            _clienteService = clienteService;
            _consumoService = consumoService;
        }

        public async Task<double> CalcularConsumoTotalCliente(int idClient)
        {
            var clientExist = await _clienteService.ExistAsync(idClient);
            if (!clientExist)
                return 0;

            var resultConsumo = await _consumoService.FindByClienIdAsync(idClient);
            var result = resultConsumo.Select(x => x.Valor).Sum();

            return result;
        }
    }
}
