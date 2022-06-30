using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VxTel.Domain.DTO;

namespace VxTel.Domain.Interface.Implementation
{
    public interface IBaseApiController<D>
        where D : BaseDTO
    {
        Task<IActionResult> Get();

        Task<IActionResult> Get(int id);

        Task<IActionResult> Post([FromBody] D dto);

        Task<IActionResult> Put(int id, [FromBody] D dto);

        Task<IActionResult> Delete(int id);
    }
}