using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Entity;

namespace VxTel.WebApiOLD.Controllers
{
    public interface ITarifaController
    {
        Task<IEnumerable<Tarifa>> Get();

        Task<Tarifa> Get(int id);
        
        Task<Tarifa> Post([FromBody] Tarifa tarifa);

        Task Put(int id, [FromBody] Tarifa tarifa);

        Task Delete(int id);
    }
}