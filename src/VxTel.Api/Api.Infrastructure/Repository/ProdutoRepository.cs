using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Infrastructure.Database;

namespace VxTel.Api.Infrastructure.Repository
{
    public sealed class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }
    }
}
