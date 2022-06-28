using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Service;

namespace VxTel.WebApiOLD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : BaseController<Produto>
    {
        public ProdutoController(IProdutoService produtoService)
            : base(produtoService)
        {
        }
    }
}
