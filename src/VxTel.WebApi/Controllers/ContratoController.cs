using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContratoController : BaseController<ContratoDTO, Contrato>
    {
        public ContratoController(IContratoService contratoService)
            : base(contratoService)
        {
        }
    }
}
