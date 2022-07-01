using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Infrastructure.Database;

namespace VxTel.Api.Infrastructure.Repository
{
    public sealed class ChamadaRepository : BaseRepository<Chamada>, IChamadaRepository
    {
        public ChamadaRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }
    }
}
