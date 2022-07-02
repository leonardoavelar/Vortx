using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Infrastructure.Database;

namespace VxTel.Api.Infrastructure.Repository
{
    public sealed class ConsumoRepository : BaseRepository<Consumo>, IConsumoRepository
    {
        public ConsumoRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }

        public async Task<IEnumerable<Consumo>> FindByClienIdAsync(int idClient)
        {
            var result = await _data.AsNoTracking()
                .Where(x => x.ClienteId == idClient)
                .ToListAsync();

            return result;
        }
    }
}
