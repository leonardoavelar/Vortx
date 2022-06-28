using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApiOLD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsumoController : BaseController<Consumo>
    {
        public ConsumoController(IConsumoService consumoService)
            : base(consumoService)
        {
        }
    }
}
