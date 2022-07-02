using System.Threading.Tasks;
using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Domain.Interface.UseCase
{
    public interface IClienteUseCase
    {
        Task<ClienteDTO> RetornaClienteContrato(int id);
    }
}
