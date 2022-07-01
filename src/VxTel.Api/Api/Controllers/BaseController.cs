using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Implementation;

namespace VxTel.Api.Controllers
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
        public async Task<IEnumerable<D>> Get()
        {
            var result = await _baseService.FindAllAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<D> Get(int id)
        {
            var result = await _baseService.FindByIdAsync(id);
            return result;
        }

        [HttpPost]
        public async Task<D> Post([FromBody] D dto)
        {
            var result = await _baseService.InsertAsync(dto);
            return result;
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] D dto)
        {
            if (dto.Id == id)
                await _baseService.UpdateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _baseService.DeleteAsync(id);
        }
    }
}
