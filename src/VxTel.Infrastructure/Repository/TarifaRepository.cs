using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public sealed class TarifaRepository : BaseRepository<Tarifa>, ITarifaRepository
    {
        public TarifaRepository(MySqlDbContext mySqlDbContext) 
            : base(mySqlDbContext)
        {
        }

        public async Task<IEnumerable<Tarifa>> FindAllAsync()
        {
            var result = await data.ToListAsync();
            return result;
        }
    }
}
