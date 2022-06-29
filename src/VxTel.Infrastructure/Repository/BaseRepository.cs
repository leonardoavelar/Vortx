using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly DbSet<T> _data;
        private readonly DatabaseContext _databaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _data = _databaseContext.Set<T>();
        }

        public async Task<T> InsertAsync(T entity)
        {
            var result = await _data.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _data.Update(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var canal = await _data.FindAsync(id);
            _data.Remove(canal);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(int id)
        {
            var result = await _data.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var result = await _data.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            var result = await _data.ToListAsync();
            return result;
        }
    }
}
