using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public sealed class ContratoRepository : BaseRepository<Contrato>, IContratoRepository
    {
        public ContratoRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }
    }
}
