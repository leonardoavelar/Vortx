using Microsoft.AspNetCore.Mvc;
using VxTel.Site.Domain.DTO;
using VxTel.Site.Domain.Interface.Refit;

namespace SalesWebMvc.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRefit _clienteRefit;

        public ClienteController(IClienteRefit clienteRefit)
        {
            _clienteRefit = clienteRefit;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            return View(await _clienteRefit.Get());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _clienteRefit.Get(id);

            if (cliente is null)
                return NotFound();

            return View(cliente);
        }

        // GET: Cliente/Create
        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteDTO cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteRefit.Post(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteRefit.Get(id);

            if (cliente is null)
                return NotFound();

            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteDTO cliente)
        {
            if (id != cliente.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _clienteRefit.Put(id, cliente);                

                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var canal = await _clienteRefit.Get(id);

            if (canal == null)
                return NotFound();

            return View(canal);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clienteRefit.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
