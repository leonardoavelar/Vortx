using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Interface.UseCase;

namespace VxTel.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class SimulacaoController : Controller
    {
        private readonly ISimulacaoUseCase _simulacaoUseCase;

        public SimulacaoController(ISimulacaoUseCase simulacaoUseCase)
        {
            _simulacaoUseCase = simulacaoUseCase;
        }

        [HttpPost]
        public async Task<IEnumerable<SimulacaoDTO>> GetAsync([FromBody] SimulacaoRequestDTO simulacaoRequest)
        {
            var result = await _simulacaoUseCase.GetSimulacaoAsync(simulacaoRequest);
            return result;
        }
    }
}
