using Microsoft.AspNetCore.Mvc;
using Inventario.DA;
using Inventario.MODEL;

namespace ProductoInventario.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoRepository _repo;

        public ProductosController(IProductoRepository repo)
        {
            _repo = repo;
        }

        // GET: /Productos
        public IActionResult Index()
        {
            var productos = _repo.ObtenerTodos();
            return View(productos);
        }

        // GET: /Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _repo.Agregar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: /Productos/Edit/5
        public IActionResult Edit(int id)
        {
            var producto = _repo.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        // POST: /Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Producto producto)
        {
            if (id != producto.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _repo.Actualizar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: /Productos/Delete/5
        public IActionResult Delete(int id)
        {
            var producto = _repo.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        // POST: /Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
