using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class TelefoneClienteService : BaseService<TelefoneClienteDTO, TelefoneCliente>, ITelefoneClienteService
    {
        public TelefoneClienteService(IMapper mapper, ITelefoneClienteRepository telefoneClienteRepository)
            : base(mapper, telefoneClienteRepository)
        {
        }
    }
}
