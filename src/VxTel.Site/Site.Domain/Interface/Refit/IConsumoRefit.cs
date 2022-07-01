using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Site.Domain.DTO;

namespace VxTel.Site.Domain.Interface.Refit
{
    public interface IConsumoRefit 
    {
        [Get("/Consumo")]
        Task<IEnumerable<ConsumoDTO>> Get();

        [Get("/Consumo/{id}")]
        Task<ConsumoDTO> Get(int id);

        [Get("/Consumo")]
        Task<ConsumoDTO> Post([FromBody] ConsumoDTO dto);

        [Get("/Consumo/{id}")]
        Task Put(int id, [FromBody] ConsumoDTO dto);

        [Get("/Consumo/{id}")]
        Task Delete(int id);
    }
}