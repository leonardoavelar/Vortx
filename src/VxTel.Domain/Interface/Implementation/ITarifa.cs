using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Entity;

namespace VxTel.Domain.Interface.Implementation
{
    public interface ITarifa : IBaseMethods<Tarifa>
    {
        Task<IEnumerable<Tarifa>> FindAllAsync();
    }
}
