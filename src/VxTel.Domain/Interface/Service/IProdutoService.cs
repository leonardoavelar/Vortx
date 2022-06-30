using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;

namespace VxTel.Domain.Interface.Service
{
    public interface IProdutoService : IBaseService<ProdutoDTO, Produto>
    {
    }
}
