using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarifaController : BaseController<TarifaDTO, Tarifa>
    {
        public TarifaController(ITarifaService tarifaService)
            : base(tarifaService)
        {
        }
    }
}
