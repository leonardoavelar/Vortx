using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VxTel.Site.Domain.DTO;
using VxTel.Site.Domain.Interface.Refit;

namespace SalesWebMvc.Controllers
{
    public class TarifaController : Controller
    {
        private readonly ITarifaRefit _tarifaRefit;

        public TarifaController(ITarifaRefit tarifaRefit)
        {
            _tarifaRefit = tarifaRefit;
        }

        // GET: Tarifa
        public async Task<IActionResult> Index()
        {
            return View(await _tarifaRefit.Get());
        }

        // GET: Tarifa/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var tarifa = await _tarifaRefit.Get(id);
            if (tarifa is null)
            {
                return NotFound();
            }

            return View(tarifa);
        }

        // GET: Tarifa/Create
        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }

        // POST: Tarifa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TarifaDTO tarifa)
        {
            if (ModelState.IsValid)
            {
                await _tarifaRefit.Post(tarifa);
                return RedirectToAction(nameof(Index));
            }
            return View(tarifa);
        }

        // GET: Tarifa/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var tarifa = await _tarifaRefit.Get(id);
            if (tarifa is null)
            {
                return NotFound();
            }
            return View(tarifa);
        }

        // POST: Tarifa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TarifaDTO tarifa)
        {
            if (id != tarifa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _tarifaRefit.Put(id, tarifa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _tarifaRefit.Exist(tarifa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tarifa);
        }

        // GET: Tarifa/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var canal = await _tarifaRefit.Get(id);
            if (canal == null)
            {
                return NotFound();
            }

            return View(canal);
        }

        // POST: Tarifa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tarifaRefit.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
