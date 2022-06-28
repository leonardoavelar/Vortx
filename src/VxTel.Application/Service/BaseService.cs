using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;

namespace VxTel.Application.Service
{
    public class BaseService<T> : IBaseService<T>
        where T : BaseEntity
    {
        private readonly IBaseRepository<T> BaseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            BaseRepository = baseRepository;
        }

        public async Task<T> InsertAsync(T entity)
        {
            var result = await BaseRepository.InsertAsync(entity);
            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            await BaseRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await BaseRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            var result = await BaseRepository.ExistAsync(id);
            return result;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var result = await BaseRepository.FindByIdAsync(id);
            return result;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            var result = await BaseRepository.FindAllAsync();
            return result;
        }
    }
}
