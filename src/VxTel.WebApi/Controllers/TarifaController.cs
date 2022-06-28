using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApiOLD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarifaController : ControllerBase
    {
        private readonly ITarifaService TarifaService;

        public TarifaController(ITarifaService tarifaService)
        {
            TarifaService = tarifaService;
        }

        [HttpGet]
        public async Task<IEnumerable<Tarifa>> Get()
        {
            var result = await TarifaService.FindAllAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Tarifa> Get(int id)
        {
            var result = await TarifaService.FindByIdAsync(id);
            return result;
        }

        [HttpPost]
        public async Task<Tarifa> Post([FromBody] Tarifa tarifa)
        {
            var result = await TarifaService.InsertAsync(tarifa);
            return result;
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Tarifa tarifa)
        {
            if (tarifa.Id == id)
                await TarifaService.UpdateAsync(tarifa);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await TarifaService.DeleteAsync(id);
        }
    }
}
