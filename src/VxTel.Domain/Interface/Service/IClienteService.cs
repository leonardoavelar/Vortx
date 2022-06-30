using System.Threading.Tasks;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;

namespace VxTel.Domain.Interface.Service
{
    public interface IClienteService : IBaseService<ClienteDTO, Cliente>
    {
        Task<ClienteDTO> RetornaClienteContratoTelefone(int id);
    }
}
