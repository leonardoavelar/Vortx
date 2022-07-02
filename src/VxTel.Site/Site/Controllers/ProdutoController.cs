using Microsoft.AspNetCore.Mvc;
using VxTel.Site.Domain.DTO;
using VxTel.Site.Domain.Interface.Refit;

namespace SalesWebMvc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRefit _produtoRefit;

        public ProdutoController(IProdutoRefit produtoRefit)
        {
            _produtoRefit = produtoRefit;
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            return View(await _produtoRefit.Get());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoRefit.Get(id);

            if (produto is null)
                return NotFound();

            return View(produto);
        }

        // GET: Produto/Create
        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoDTO produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoRefit.Post(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtoRefit.Get(id);

            if (produto is null)
                return NotFound();

            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoDTO produto)
        {
            if (id != produto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _produtoRefit.Put(id, produto);                

                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var canal = await _produtoRefit.Get(id);

            if (canal == null)
                return NotFound();

            return View(canal);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produtoRefit.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
