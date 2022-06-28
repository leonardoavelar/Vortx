using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApiOLD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TelefoneClienteController : BaseController<TelefoneCliente>
    {
        public TelefoneClienteController(ITelefoneClienteService telefoneClienteService)
            : base(telefoneClienteService)
        {
        }
    }
}
