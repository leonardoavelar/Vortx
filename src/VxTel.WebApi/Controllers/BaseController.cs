using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;

namespace VxTel.WebApiOLD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase, IBaseApiController<T>
        where  T : BaseEntity
    {
        private readonly IBaseService<T> BaseService;

        public BaseController(IBaseService<T> baseService)
        {
            BaseService = baseService;
        }

        [HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            var result = await BaseService.FindAllAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<T> Get(int id)
        {
            var result = await BaseService.FindByIdAsync(id);
            return result;
        }

        [HttpPost]
        public async Task<T> Post([FromBody] T entity)
        {
            var result = await BaseService.InsertAsync(entity);
            return result;
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] T entity)
        {
            if (entity.Id == id)
                await BaseService.UpdateAsync(entity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await BaseService.DeleteAsync(id);
        }
    }
}
