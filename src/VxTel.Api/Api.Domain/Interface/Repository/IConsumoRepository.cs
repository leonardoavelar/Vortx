using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Implementation;

namespace VxTel.Api.Domain.Interface.Repository
{
    public interface IConsumoRepository : IBaseRepository<Consumo>
    {
        Task<IEnumerable<Consumo>> FindByClienIdAsync(int idClient);
    }
}
