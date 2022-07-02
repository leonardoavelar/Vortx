using Microsoft.AspNetCore.Mvc;
using VxTel.Site.Domain.DTO;
using VxTel.Site.Domain.Interface.Refit;

namespace SalesWebMvc.Controllers
{
    public class ChamadaController : Controller
    {
        private readonly IChamadaRefit _chamadaRefit;

        public ChamadaController(IChamadaRefit chamadaRefit)
        {
            _chamadaRefit = chamadaRefit;
        }

        // GET: Chamada
        public async Task<IActionResult> Index()
        {
            return View(await _chamadaRefit.Get());
        }

        // GET: Chamada/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var chamada = await _chamadaRefit.Get(id);

            if (chamada is null)
                return NotFound();

            return View(chamada);
        }

        // GET: Chamada/Create
        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }

        // POST: Chamada/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChamadaDTO chamada)
        {
            if (ModelState.IsValid)
            {
                await _chamadaRefit.Post(chamada);
                return RedirectToAction(nameof(Index));
            }
            return View(chamada);
        }

        // GET: Chamada/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var chamada = await _chamadaRefit.Get(id);

            if (chamada is null)
                return NotFound();

            return View(chamada);
        }

        // POST: Chamada/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ChamadaDTO chamada)
        {
            if (id != chamada.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _chamadaRefit.Put(id, chamada);                

                return RedirectToAction(nameof(Index));
            }
            return View(chamada);
        }

        // GET: Chamada/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var canal = await _chamadaRefit.Get(id);

            if (canal == null)
                return NotFound();

            return View(canal);
        }

        // POST: Chamada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _chamadaRefit.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
