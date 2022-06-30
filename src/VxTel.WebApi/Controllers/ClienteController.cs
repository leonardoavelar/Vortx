using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : BaseController<ClienteDTO, Cliente>
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
            : base(clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{id}/Dados")]
        public async Task<IActionResult> GetClienteContratoTelefone(int id)
        {
            var result = await _clienteService.RetornaClienteContratoTelefone(id);
            return Ok(result);
        }
    }
}
