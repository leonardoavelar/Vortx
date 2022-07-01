using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Infrastructure.Database;

namespace VxTel.Api.Infrastructure.Repository
{
    public sealed class TarifaRepository : BaseRepository<Tarifa>, ITarifaRepository
    {
        public TarifaRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }
    }
}
