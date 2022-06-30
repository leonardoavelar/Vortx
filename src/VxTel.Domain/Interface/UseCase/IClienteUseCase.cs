using System.Threading.Tasks;
using VxTel.Domain.DTO;

namespace VxTel.Domain.Interface.UseCase
{
    public interface IClienteUseCase
    {
        Task<ClienteDTO> RetornaClienteContratoTelefone(int id);
    }
}
