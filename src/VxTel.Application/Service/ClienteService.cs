using AutoMapper;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;
using VxTel.Domain.DTO;

namespace VxTel.Application.Service
{
    public sealed class ClienteService : BaseService<ClienteDTO, Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
            : base(mapper, clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> RetornaClienteContratoTelefone(int id)
        {
            var resultEntity = await _clienteRepository.RetornaClienteContratoTelefone(id);
            var result = _mapper.Map<ClienteDTO>(resultEntity);
            return result;
        }
    }
}
