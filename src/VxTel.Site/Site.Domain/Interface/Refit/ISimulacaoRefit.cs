using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;
using VxTel.Site.Domain.DTO;

namespace VxTel.Site.Domain.Interface.Refit
{
    public interface ISimulacaoRefit 
    {
        [Post("/Simulacao")]
        Task<SimulacaoResponseDTO> PostAsync([FromBody] SimulacaoRequestDTO simulacaoRequest);
    }
}