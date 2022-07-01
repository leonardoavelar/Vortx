using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Site.Domain.DTO;

namespace VxTel.Site.Domain.Interface.Refit
{
    public interface ITarifaRefit 
    {
        [Get("/Tarifa")]
        Task<IEnumerable<TarifaDTO>> Get();

        [Get("/Tarifa/{id}")]
        Task<TarifaDTO> Get(int id);

        [Get("/Tarifa")]
        Task<TarifaDTO> Post([FromBody] TarifaDTO dto);

        [Get("/Tarifa/{id}")]
        Task Put(int id, [FromBody] TarifaDTO dto);

        [Get("/Tarifa/{id}")]
        Task Delete(int id);
    }
}