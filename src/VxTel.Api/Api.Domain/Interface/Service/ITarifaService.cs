using System.Threading.Tasks;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Implementation;

namespace VxTel.Api.Domain.Interface.Service
{
    public interface ITarifaService : IBaseService<TarifaDTO, Tarifa>
    {
        Task<TarifaDTO> FindByOrigemDestinoAsync(string dddOrigem, string dddDestino);
    }
}
