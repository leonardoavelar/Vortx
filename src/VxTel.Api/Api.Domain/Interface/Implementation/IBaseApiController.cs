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
        Task<IEnumerable<D>> GetAsync();

        [HttpGet("{id}")]
        Task<D> GetAsync(int id);

        [HttpPost]
        Task<D> PostAsync([FromBody] D dto);

        [HttpPut("{id}")]
        Task PutAsync(int id, [FromBody] D dto);

        [HttpDelete("{id}")]
        Task DeleteAsync(int id);
    }
}