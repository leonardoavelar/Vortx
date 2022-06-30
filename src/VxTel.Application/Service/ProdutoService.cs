using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class ProdutoService : BaseService<ProdutoDTO, Produto>, IProdutoService
    {
        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
            : base(mapper, produtoRepository)
        {
        }
    }
}
