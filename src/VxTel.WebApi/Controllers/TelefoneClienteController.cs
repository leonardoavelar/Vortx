using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TelefoneClienteController : BaseController<TelefoneClienteDTO, TelefoneCliente>
    {
        public TelefoneClienteController(ITelefoneClienteService telefoneClienteService)
            : base(telefoneClienteService)
        {
        }
    }
}
