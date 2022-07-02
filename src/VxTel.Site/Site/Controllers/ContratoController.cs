using Microsoft.AspNetCore.Mvc;
using VxTel.Site.Domain.DTO;
using VxTel.Site.Domain.Interface.Refit;

namespace SalesWebMvc.Controllers
{
    public class ContratoController : Controller
    {
        private readonly IContratoRefit _contratoRefit;

        public ContratoController(IContratoRefit contratoRefit)
        {
            _contratoRefit = contratoRefit;
        }

        // GET: Contrato
        public async Task<IActionResult> Index()
        {
            return View(await _contratoRefit.Get());
        }

        // GET: Contrato/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var contrato = await _contratoRefit.Get(id);

            if (contrato is null)
                return NotFound();

            return View(contrato);
        }

        // GET: Contrato/Create
        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }

        // POST: Contrato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContratoDTO contrato)
        {
            if (ModelState.IsValid)
            {
                await _contratoRefit.Post(contrato);
                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }

        // GET: Contrato/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var contrato = await _contratoRefit.Get(id);

            if (contrato is null)
                return NotFound();

            return View(contrato);
        }

        // POST: Contrato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContratoDTO contrato)
        {
            if (id != contrato.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _contratoRefit.Put(id, contrato);                

                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }

        // GET: Contrato/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var canal = await _contratoRefit.Get(id);

            if (canal == null)
                return NotFound();

            return View(canal);
        }

        // POST: Contrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _contratoRefit.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
