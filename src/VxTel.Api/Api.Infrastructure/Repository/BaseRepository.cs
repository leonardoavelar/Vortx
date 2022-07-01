using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Implementation;
using VxTel.Api.Infrastructure.Database;

namespace VxTel.Api.Infrastructure.Repository
{
    public abstract class BaseRepository<E> : IBaseRepository<E>
        where E : BaseEntity
    {
        protected readonly DbSet<E> Data;
        private readonly DatabaseContext DatabaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
            Data = DatabaseContext.Set<E>();
        }

        public async Task<E> InsertAsync(E entity)
        {
            var result = await Data.AddAsync(entity);
            await DatabaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync(E entity)
        {
            Data.Update(entity);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var canal = await Data.FindAsync(id);
            Data.Remove(canal);
            await DatabaseContext.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(int id)
        {
            var result = await Data.AsNoTracking()
                .AnyAsync(x => x.Id == id);

            return result;
        }

        public async Task<E> FindByIdAsync(int id)
        {
            var result = await Data.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<IEnumerable<E>> FindAllAsync()
        {
            var result = await Data.AsNoTracking()
                .ToListAsync();

            return result;
        }
    }
}
