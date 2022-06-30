using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;

namespace VxTel.WebApi.Controllers
{
    public class BaseController<D, E> : ControllerBase, IBaseApiController<D>
        where D : BaseDTO
        where E : BaseEntity
    {
        private readonly IBaseService<D, E> _baseService;

        public BaseController(IBaseService<D, E> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _baseService.FindAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _baseService.FindByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] D dto)
        {
            var result = await _baseService.InsertAsync(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] D dto)
        {
            if (dto.Id == id)
                await _baseService.UpdateAsync(dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _baseService.DeleteAsync(id);
            return Ok();
        }
    }
}
