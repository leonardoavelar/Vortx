using VxTel.Domain.Entity;

namespace VxTel.Domain.Interface.Implementation
{
    public interface IBaseRepository<T> : IBaseMethods<T>
        where T : BaseEntity
    {
    }
}
