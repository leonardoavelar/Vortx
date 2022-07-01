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

        [Post("/Tarifa")]
        Task<TarifaDTO> Post([FromBody] TarifaDTO dto);

        [Put("/Tarifa/{id}")]
        Task Put(int id, [FromBody] TarifaDTO dto);

        [Delete("/Tarifa/{id}")]
        Task Delete(int id);
    }
}