using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
        }
    }
}
