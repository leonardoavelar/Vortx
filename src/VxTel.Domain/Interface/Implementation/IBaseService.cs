using VxTel.Domain.Entity;

namespace VxTel.Domain.Interface.Implementation
{
    public interface IBaseService<T> : IBaseMethods<T>
        where T : BaseEntity
    {
    }
}
