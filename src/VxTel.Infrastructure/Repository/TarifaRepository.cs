using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public sealed class TarifaRepository : BaseRepository<Tarifa>, ITarifaRepository
    {
        public TarifaRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }
    }
}
