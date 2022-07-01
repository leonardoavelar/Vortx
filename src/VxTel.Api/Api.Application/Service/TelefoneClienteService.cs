using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Domain.Interface.Service;

namespace VxTel.Api.Application.Service
{
    public sealed class TelefoneClienteService : BaseService<TelefoneClienteDTO, TelefoneCliente>, ITelefoneClienteService
    {
        public TelefoneClienteService(IMapper mapper, ITelefoneClienteRepository telefoneClienteRepository)
            : base(mapper, telefoneClienteRepository)
        {
        }
    }
}
