using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Domain.Interface.UseCase
{
    public interface ISimulacaoUseCase
    {
        Task<IEnumerable<SimulacaoDTO>> GetSimulacaoAsync(SimulacaoRequestDTO simulacaoRequest);
    }
}
