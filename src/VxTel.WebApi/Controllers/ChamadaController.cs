using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChamadaController : BaseController<ChamadaDTO, Chamada>
    {
        public ChamadaController(IChamadaService chamadaService)
            : base(chamadaService)
        {
        }
    }
}
