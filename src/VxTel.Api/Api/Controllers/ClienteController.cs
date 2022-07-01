using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Service;

namespace VxTel.Api.Controllers
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
        public async Task<ClienteDTO> GetClienteContratoTelefone(int id)
        {
            var result = await _clienteService.RetornaClienteContratoTelefone(id);
            return result;
        }
    }
}
