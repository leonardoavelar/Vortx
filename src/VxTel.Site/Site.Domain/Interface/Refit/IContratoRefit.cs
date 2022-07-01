using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Site.Domain.DTO;

namespace VxTel.Site.Domain.Interface.Refit
{
    public interface IContratoRefit 
    {
        [Get("/Contrato")]
        Task<IEnumerable<ContratoDTO>> Get();

        [Get("/Contrato/{id}")]
        Task<ContratoDTO> Get(int id);

        [Get("/Contrato")]
        Task<ContratoDTO> Post([FromBody] ContratoDTO dto);

        [Get("/Contrato/{id}")]
        Task Put(int id, [FromBody] ContratoDTO dto);

        [Get("/Contrato/{id}")]
        Task Delete(int id);
    }
}