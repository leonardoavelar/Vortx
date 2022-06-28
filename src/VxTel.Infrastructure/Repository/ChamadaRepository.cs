using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public sealed class ChamadaRepository : BaseRepository<Chamada>, IChamadaRepository
    {
        public ChamadaRepository(MySqlDbContext mySqlDbContext) 
            : base(mySqlDbContext)
        {
        }
    }
}
