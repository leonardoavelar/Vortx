using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseMethods<T>
        where T : BaseEntity
    {
        protected readonly DbSet<T> data;
        private readonly MySqlDbContext MySqlDbContext;

        public BaseRepository(MySqlDbContext mySqlDbContext)
        {
            MySqlDbContext = mySqlDbContext;
            data = MySqlDbContext.Set<T>();
        }

        public async Task<T> InsertAsync(T entity)
        {
            var result = await data.AddAsync(entity);
            await MySqlDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync(T entity)
        {
            data.Update(entity);
            await MySqlDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var canal = await data.FindAsync(id);
            data.Remove(canal);
            await MySqlDbContext.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(int id)
        {
            var result = await data.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var result = await data.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
