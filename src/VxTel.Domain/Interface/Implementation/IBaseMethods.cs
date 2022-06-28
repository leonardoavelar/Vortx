using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Entity;

namespace VxTel.Domain.Interface.Implementation
{
    public interface IBaseMethods<T>
        where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<bool> ExistAsync(int id);

        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> FindAllAsync();
    }
}
