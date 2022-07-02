using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Implementation;
using VxTel.Api.Infrastructure.Database;

namespace VxTel.Api.Infrastructure.Repository
{
    public class BaseRepository<E> : IBaseRepository<E>
        where E : BaseEntity
    {
        protected readonly DbSet<E> _data;
        private readonly DatabaseContext _databaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _data = _databaseContext.Set<E>();
        }

        public async Task<E> InsertAsync(E entity)
        {
            var result = await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync(E entity)
        {
            _databaseContext.Update(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var canal = await _data.FindAsync(id);
            _databaseContext.Remove(canal);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(int id)
        {
            var result = await _data.AsNoTracking()
                .AnyAsync(x => x.Id == id);

            return result;
        }

        public async Task<E> FindByIdAsync(int id)
        {
            var result = await _data.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<IEnumerable<E>> FindAllAsync()
        {
            var result = await _data.AsNoTracking()
                .ToListAsync();

            return result;
        }
    }
}
