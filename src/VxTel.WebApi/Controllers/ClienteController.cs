using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApiOLD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : BaseController<Cliente>
    {
        public ClienteController(IClienteService clienteService)
            : base(clienteService)
        {
        }
    }
}
