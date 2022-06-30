using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;

namespace VxTel.Domain.Interface.Implementation
{
    public interface IBaseService<D, E>
        where D : BaseDTO
        where E : BaseEntity
    {
        Task<D> InsertAsync(D dto);

        Task UpdateAsync(D dto);

        Task DeleteAsync(int id);

        Task<bool> ExistAsync(int id);

        Task<D> FindByIdAsync(int id);

        Task<IEnumerable<D>> FindAllAsync();
    }
}
