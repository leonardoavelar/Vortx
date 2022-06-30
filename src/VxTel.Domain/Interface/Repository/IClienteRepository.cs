using System.Threading.Tasks;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;

namespace VxTel.Domain.Interface.Repository
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> RetornaClienteContratoTelefone(int id);
    }
}
