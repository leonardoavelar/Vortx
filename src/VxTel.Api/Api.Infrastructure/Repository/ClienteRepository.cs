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

        public async Task<Cliente> RetornaClienteContratoTelefone(int id)
        {
            var result = await Data.AsNoTracking()
                .Include(x => x.Contratos)
                .Include(x => x.TelefonesCliente)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
