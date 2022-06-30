using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public sealed class ConsumoRepository : BaseRepository<Consumo>, IConsumoRepository
    {
        public ConsumoRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }

        public async Task<IEnumerable<Consumo>> FindByClienIdAsync(int idClient)
        {
            var result = await Data.AsNoTracking()
                .Where(x => x.ClienteId == idClient)
                .ToListAsync();

            return result;
        }
    }
}
