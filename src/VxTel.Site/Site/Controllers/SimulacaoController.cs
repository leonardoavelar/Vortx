using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VxTel.Site.Domain.DTO;
using VxTel.Site.Domain.Interface.Refit;

namespace Site.Controllers
{
    public class SimulacaoController : Controller
    {
        private readonly ITarifaRefit _tarifaRefit;
        private readonly IProdutoRefit _produtoRefit;
        private readonly ISimulacaoRefit _simulacaoRefit;

        public SimulacaoController(ITarifaRefit tarifaRefit, IProdutoRefit produtoRefit, ISimulacaoRefit simulacaoRefit)
        {
            _tarifaRefit = tarifaRefit;
            _produtoRefit = produtoRefit;
            _simulacaoRefit = simulacaoRefit;
        }

        public async Task<IActionResult> Index(SimulacaoRequestDTO simulacaoRequest)
        {
            var tarifas = await _tarifaRefit.Get();
            var produtos = await _produtoRefit.Get();

            if (tarifas is not null && produtos is not null)
            {
                var listDddOrigem = tarifas.OrderBy(x => x.DddOrigem).Select(x => x.DddOrigem).Distinct().ToList();
                ViewBag.ListDddOrigem = listDddOrigem.Select(x => new SelectListItem(x, null, x == simulacaoRequest.DddOrigem));

                var listDddDestino = tarifas.OrderBy(x => x.DddDestino).Select(x => x.DddDestino).Distinct().ToList();
                ViewBag.ListDddDestino = listDddDestino.Select(x => new SelectListItem(x, null, x == simulacaoRequest.DddDestino));

                var listProduto = produtos.Select(x => new SelectListItem(x.Nome, x.Id.ToString(), x.Id == simulacaoRequest.ProdutoId));
                ViewBag.ListProduto = listProduto;
            }

            if (simulacaoRequest.Simular)
            {
                var result = await _simulacaoRefit.PostAsync(simulacaoRequest);
                ViewBag.SimulacaoResponse = result.Simulacao;

                return View(result.SimulacaoRequest);
            }

            ViewBag.SimulacaoResponse = new List<SimulacaoDTO>();
            return View(simulacaoRequest);
        }

        public IActionResult Simulacao(SimulacaoRequestDTO simulacaoRequest)
        {
            simulacaoRequest.Simular = true;
            return RedirectToAction("Index", simulacaoRequest);
        }
    }
}