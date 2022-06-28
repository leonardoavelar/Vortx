using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApiOLD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChamadaController : BaseController<Chamada>
    {
        public ChamadaController(IChamadaService chamadaService)
            : base(chamadaService)
        {
        }
    }
}
