using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;

namespace VxTel.Domain.Interface.Repository
{
    public interface IConsumoRepository : IBaseRepository<Consumo>
    {
        Task<IEnumerable<Consumo>> FindByClienIdAsync(int idClient);
    }
}
