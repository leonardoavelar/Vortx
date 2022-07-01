using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Site.Domain.DTO;

namespace VxTel.Site.Domain.Interface.Refit
{
    public interface IProdutoRefit 
    {
        [Get("/Produto")]
        Task<IEnumerable<ProdutoDTO>> Get();

        [Get("/Produto/{id}")]
        Task<ProdutoDTO> Get(int id);

        [Post("/Produto")]
        Task<ProdutoDTO> Post([FromBody] ProdutoDTO dto);

        [Put("/Produto/{id}")]
        Task Put(int id, [FromBody] ProdutoDTO dto);

        [Delete("/Produto/{id}")]
        Task Delete(int id);
    }
}