using Microsoft.AspNetCore.Mvc;
using VxTel.Site.Domain.DTO;
using VxTel.Site.Domain.Interface.Refit;

namespace SalesWebMvc.Controllers
{
    public class ConsumoController : Controller
    {
        private readonly IConsumoRefit _consumoRefit;

        public ConsumoController(IConsumoRefit consumoRefit)
        {
            _consumoRefit = consumoRefit;
        }

        // GET: Consumo
        public async Task<IActionResult> Index()
        {
            return View(await _consumoRefit.Get());
        }

        // GET: Consumo/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var consumo = await _consumoRefit.Get(id);

            if (consumo is null)
                return NotFound();

            return View(consumo);
        }

        // GET: Consumo/Create
        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }

        // POST: Consumo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConsumoDTO consumo)
        {
            if (ModelState.IsValid)
            {
                await _consumoRefit.Post(consumo);
                return RedirectToAction(nameof(Index));
            }
            return View(consumo);
        }

        // GET: Consumo/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var consumo = await _consumoRefit.Get(id);

            if (consumo is null)
                return NotFound();

            return View(consumo);
        }

        // POST: Consumo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConsumoDTO consumo)
        {
            if (id != consumo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _consumoRefit.Put(id, consumo);                

                return RedirectToAction(nameof(Index));
            }
            return View(consumo);
        }

        // GET: Consumo/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var canal = await _consumoRefit.Get(id);

            if (canal == null)
                return NotFound();

            return View(canal);
        }

        // POST: Consumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _consumoRefit.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
