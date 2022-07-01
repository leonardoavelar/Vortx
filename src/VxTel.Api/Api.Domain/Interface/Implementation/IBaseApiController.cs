using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Domain.Interface.Implementation
{
    public interface IBaseApiController<D>
        where D : BaseDTO
    {
        [HttpGet]
        Task<IEnumerable<D>> Get();

        [HttpGet("{id}")]
        Task<D> Get(int id);

        [HttpPost]
        Task<D> Post([FromBody] D dto);

        [HttpPut("{id}")]
        Task Put(int id, [FromBody] D dto);

        [HttpDelete("{id}")]
        Task Delete(int id);
    }
}