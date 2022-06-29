using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public sealed class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }
    }
}
