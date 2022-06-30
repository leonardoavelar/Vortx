using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;
using VxTel.Domain.Interface.UseCase;

namespace VxTel.WebApi.Controllers
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
        public async Task<IActionResult> GetConsumoCliente(int idClient)
        {
            var result = await _consumoUseCase.CalcularConsumoTotalCliente(idClient);
            return Ok(result);
        }
    }
}
