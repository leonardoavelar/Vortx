using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Infrastructure.Database;

namespace VxTel.Api.Infrastructure.Repository
{
    public sealed class ContratoRepository : BaseRepository<Contrato>, IContratoRepository
    {
        public ContratoRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }
    }
}
