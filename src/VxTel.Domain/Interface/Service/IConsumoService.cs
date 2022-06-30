using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;

namespace VxTel.Domain.Interface.Service
{
    public interface IConsumoService : IBaseService<ConsumoDTO, Consumo>
    {
        Task<IEnumerable<ConsumoDTO>> FindByClienIdAsync(int idClient);
    }
}
