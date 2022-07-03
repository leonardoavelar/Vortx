using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Site.Models;
using System.Diagnostics;
using VxTel.Site.Domain.DTO;
using VxTel.Site.Domain.Interface.Refit;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITarifaRefit _tarifaRefit;
        private readonly ISimulacaoRefit _simulacaoRefit;

        public HomeController(ILogger<HomeController> logger, ITarifaRefit tarifaRefit, ISimulacaoRefit simulacaoRefit)
        {
            _logger = logger;
            _tarifaRefit = tarifaRefit;
            _simulacaoRefit = simulacaoRefit;
        }

        public async Task<IActionResult> Index(SimulacaoRequestDTO simulacaoRequest)
        {
            var tarifas = await _tarifaRefit.Get();

            if (tarifas is not null)
            {
                var listDddOrigem = tarifas.OrderBy(x => x.DddOrigem).Select(x => x.DddOrigem).Distinct().ToList();
                ViewBag.ListDddOrigem = listDddOrigem.Select(x => new SelectListItem(x, null, x == simulacaoRequest.DddOrigem));

                var listDddDestino = tarifas.OrderBy(x => x.DddDestino).Select(x => x.DddDestino).Distinct().ToList();
                ViewBag.ListDddDestino = listDddDestino.Select(x => new SelectListItem(x, null, x == simulacaoRequest.DddDestino));
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}