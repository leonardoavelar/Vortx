using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class TelefoneClienteService : BaseService<TelefoneCliente>, ITelefoneClienteService
    {
        public TelefoneClienteService(ITelefoneClienteRepository telefoneClienteRepository)
            : base(telefoneClienteRepository)
        {
        }
    }
}
