using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public sealed class TelefoneClienteRepository : BaseRepository<TelefoneCliente>, ITelefoneClienteRepository
    {
        public TelefoneClienteRepository(MySqlDbContext mySqlDbContext) 
            : base(mySqlDbContext)
        {
        }
    }
}
