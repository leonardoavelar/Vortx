using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Site.Domain.DTO;

namespace VxTel.Site.Domain.Interface.Refit
{
    public interface IChamadaRefit
    {
        [Get("/Chamada")]
        Task<IEnumerable<ChamadaDTO>> Get();

        [Get("/Chamada/{id}")]
        Task<ChamadaDTO> Get(int id);

        [Get("/Chamada")]
        Task<ChamadaDTO> Post([FromBody] ChamadaDTO dto);

        [Get("/Chamada/{id}")]
        Task Put(int id, [FromBody] ChamadaDTO dto);

        [Get("/Chamada/{id}")]
        Task Delete(int id);
    }
}