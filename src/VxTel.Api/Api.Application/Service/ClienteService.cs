using AutoMapper;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Domain.Interface.Service;
using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Application.Service
{
    public sealed class ClienteService : BaseService<ClienteDTO, Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
            : base(mapper, clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> RetornaClienteContrato(int id)
        {
            var resultEntity = await _clienteRepository.RetornaClienteContrato(id);
            var result = _mapper.Map<ClienteDTO>(resultEntity);
            return result;
        }
    }
}
