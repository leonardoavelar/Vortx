using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Service;

namespace VxTel.Api.Controllers
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
