using System.Threading.Tasks;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Implementation;

namespace VxTel.Api.Domain.Interface.Repository
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> RetornaClienteContrato(int id);
    }
}
