using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Infrastructure.Database;
using System.Linq;

namespace VxTel.Api.Infrastructure.Repository
{
    public sealed class TarifaRepository : BaseRepository<Tarifa>, ITarifaRepository
    {
        public TarifaRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }

        public async Task<Tarifa> FindByOrigemDestinoAsync(string dddOrigem, string dddDestino)
        {
            var result = await _data.AsNoTracking()
                .Where(x => x.DddOrigem == dddOrigem && x.DddDestino == dddDestino)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
