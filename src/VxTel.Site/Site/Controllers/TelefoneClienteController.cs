using Microsoft.AspNetCore.Mvc;
using VxTel.Site.Domain.DTO;
using VxTel.Site.Domain.Interface.Refit;

namespace SalesWebMvc.Controllers
{
    public class TelefoneClienteController : Controller
    {
        private readonly ITelefoneClienteRefit _telefoneClienteRefit;

        public TelefoneClienteController(ITelefoneClienteRefit telefoneClienteRefit)
        {
            _telefoneClienteRefit = telefoneClienteRefit;
        }

        // GET: TelefoneCliente
        public async Task<IActionResult> Index()
        {
            return View(await _telefoneClienteRefit.Get());
        }

        // GET: TelefoneCliente/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var telefoneCliente = await _telefoneClienteRefit.Get(id);

            if (telefoneCliente is null)
                return NotFound();

            return View(telefoneCliente);
        }

        // GET: TelefoneCliente/Create
        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }

        // POST: TelefoneCliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TelefoneClienteDTO telefoneCliente)
        {
            if (ModelState.IsValid)
            {
                await _telefoneClienteRefit.Post(telefoneCliente);
                return RedirectToAction(nameof(Index));
            }
            return View(telefoneCliente);
        }

        // GET: TelefoneCliente/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var telefoneCliente = await _telefoneClienteRefit.Get(id);

            if (telefoneCliente is null)
                return NotFound();

            return View(telefoneCliente);
        }

        // POST: TelefoneCliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TelefoneClienteDTO telefoneCliente)
        {
            if (id != telefoneCliente.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _telefoneClienteRefit.Put(id, telefoneCliente);                

                return RedirectToAction(nameof(Index));
            }
            return View(telefoneCliente);
        }

        // GET: TelefoneCliente/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var canal = await _telefoneClienteRefit.Get(id);

            if (canal == null)
                return NotFound();

            return View(canal);
        }

        // POST: TelefoneCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _telefoneClienteRefit.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
