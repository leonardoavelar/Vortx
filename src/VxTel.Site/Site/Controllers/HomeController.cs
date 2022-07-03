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
                var tarifaAtual = tarifas.FirstOrDefault(x => x.Id == simulacaoRequest.TarifaId);

                if (tarifaAtual is null)
                {
                    tarifaAtual = tarifas.FirstOrDefault();
                    simulacaoRequest.TarifaId = tarifaAtual.Id;
                }

                var listDddOrigem = tarifas.Select(x => x.DddOrigem).Distinct().ToList();
                ViewBag.ListDddOrigem = listDddOrigem.Select(x => new SelectListItem(x, null, x == tarifaAtual.DddOrigem));
                ViewBag.ListDddDestino = tarifas.Where(x => x.DddOrigem == tarifaAtual.DddOrigem).Select(x => new SelectListItem(x.DddDestino, x.Id.ToString(), x.DddDestino == tarifaAtual.DddDestino));
                //}
                //else
                //{
                //    var listDddOrigem = tarifas.Select(x => x.DddOrigem).Distinct().ToList();
                //    ViewBag.ListDddOrigem = listDddOrigem.Select(x => new SelectListItem(x, null, x == simulacaoRequest.DddOrigem));
                //    ViewBag.ListDddDestino = tarifas.Where(x => x.DddOrigem == tarifaAtual.DddOrigem).Select(x => new SelectListItem(x.DddDestino, x.Id.ToString(), x.DddDestino == simulacaoRequest.DddDestino));
                //}
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

        //[HttpPost]
        //public async Task SelecionaDddDestino(string dddOrigem)
        //{
        //    var tarifas = await _tarifaRefit.Get();

        //    var result = tarifas.Where(x => x.DddOrigem == dddOrigem)
        //        .Select(x => new SelectListItem(x.DddDestino, x.Id.ToString()));

        //    ViewBag.ListDddDestino = result;
        //}

        [HttpPost]
        public async Task<IActionResult> SelecionaDddDestino(string dddOrigem)
        {
            var tarifas = await _tarifaRefit.Get();

            var result = tarifas.Where(x => x.DddOrigem == dddOrigem)
                .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.DddDestino }).ToList();

            return Json(result);
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