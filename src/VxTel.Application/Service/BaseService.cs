using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;

namespace VxTel.Application.Service
{
    public class BaseService<T> : IBaseService<T>
        where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<T> InsertAsync(T entity)
        {
            var result = await _baseRepository.InsertAsync(entity);
            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            await _baseRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            var result = await _baseRepository.ExistAsync(id);
            return result;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var result = await _baseRepository.FindByIdAsync(id);
            return result;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            var result = await _baseRepository.FindAllAsync();
            return result;
        }
    }
}
