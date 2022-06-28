using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApiOLD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarifaController : BaseController<Tarifa>
    {
        public TarifaController(ITarifaService tarifaService)
            : base(tarifaService)
        {
        }
    }
}
