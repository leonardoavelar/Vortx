using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;

namespace VxTel.Api.Domain.Interface.Implementation
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
