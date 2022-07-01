using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Domain.Interface.Service;

namespace VxTel.Api.Application.Service
{
    public sealed class ProdutoService : BaseService<ProdutoDTO, Produto>, IProdutoService
    {
        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
            : base(mapper, produtoRepository)
        {
        }
    }
}
