using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApiOLD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContratoController : BaseController<Contrato>
    {
        public ContratoController(IContratoService contratoService)
            : base(contratoService)
        {
        }
    }
}
