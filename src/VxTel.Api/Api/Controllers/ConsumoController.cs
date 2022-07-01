using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Service;
using VxTel.Api.Domain.Interface.UseCase;

namespace VxTel.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsumoController : BaseController<ConsumoDTO, Consumo>
    {
        private readonly IConsumoUseCase _consumoUseCase;

        public ConsumoController(IConsumoService consumoService, IConsumoUseCase consumoUseCase)
            : base(consumoService)
        {
            _consumoUseCase = consumoUseCase;   
        }

        [HttpGet("Cliente/{idClient}")]
        public async Task<double> GetConsumoCliente(int idClient)
        {
            var result = await _consumoUseCase.CalcularConsumoTotalCliente(idClient);
            return result;
        }
    }
}
