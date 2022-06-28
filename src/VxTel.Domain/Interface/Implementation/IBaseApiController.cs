using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Entity;

namespace VxTel.Domain.Interface.Implementation
{
    public interface IBaseApiController<T>
        where T : BaseEntity
    {
        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        Task<T> Post([FromBody] T entity);

        Task Put(int id, [FromBody] T entity);

        Task Delete(int id);
    }
}