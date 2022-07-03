using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Infrastructure.Database;

namespace VxTel.Api.Infrastructure.Repository
{
    public sealed class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }

        public async Task<Cliente> RetornaClienteContratoAsync(int id)
        {
            var result = await _data.AsNoTracking()
                .Include(x => x.Contratos)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
