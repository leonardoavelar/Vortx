using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Infrastructure.Database;

namespace VxTel.Infrastructure.Repository
{
    public sealed class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }
    }
}
