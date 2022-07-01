using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Infrastructure.Database;

namespace VxTel.Api.Infrastructure.Repository
{
    public sealed class TelefoneClienteRepository : BaseRepository<TelefoneCliente>, ITelefoneClienteRepository
    {
        public TelefoneClienteRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }
    }
}
