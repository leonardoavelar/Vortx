using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Entity;

namespace VxTel.Domain.Interface.Implementation
{
    public interface IBaseRepository<E>
        where E : BaseEntity
    {
        Task<E> InsertAsync(E entity);

        Task UpdateAsync(E entity);

        Task DeleteAsync(int id);

        Task<bool> ExistAsync(int id);

        Task<E> FindByIdAsync(int id);

        Task<IEnumerable<E>> FindAllAsync();
    }
}
