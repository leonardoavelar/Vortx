using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class ProdutoService : BaseService<Produto>, IProdutoService
    {
        public ProdutoService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
        }
    }
}
