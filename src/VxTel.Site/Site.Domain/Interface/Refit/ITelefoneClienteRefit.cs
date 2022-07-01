using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Site.Domain.DTO;

namespace VxTel.Site.Domain.Interface.Refit
{
    public interface ITelefoneClienteRefit
    {
        [Get("/TelefoneCliente")]
        Task<IEnumerable<TelefoneClienteDTO>> Get();

        [Get("/TelefoneCliente/{id}")]
        Task<TelefoneClienteDTO> Get(int id);

        [Get("/TelefoneCliente")]
        Task<TelefoneClienteDTO> Post([FromBody] TelefoneClienteDTO dto);

        [Get("/TelefoneCliente/{id}")]
        Task Put(int id, [FromBody] TelefoneClienteDTO dto);

        [Get("/TelefoneCliente/{id}")]
        Task Delete(int id);
    }
}