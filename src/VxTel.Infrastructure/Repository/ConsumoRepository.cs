using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public sealed class ConsumoRepository : BaseRepository<Consumo>, IConsumoRepository
    {
        public ConsumoRepository(MySqlDbContext mySqlDbContext) 
            : base(mySqlDbContext)
        {
        }
    }
}
