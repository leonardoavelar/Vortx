using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : BaseController<ProdutoDTO, Produto>
    {
        public ProdutoController(IProdutoService produtoService)
            : base(produtoService)
        {
        }
    }
}
