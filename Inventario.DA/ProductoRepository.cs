using System.Collections.Generic;
using System.Linq;
using Inventario.MODEL;
using Microsoft.EntityFrameworkCore;

namespace Inventario.DA
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _context.Productos.OrderByDescending(p => p.FechaIngreso).ToList();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _context.Productos.Find(id);
        }

        public void Agregar(Producto p)
        {
            _context.Productos.Add(p);
            _context.SaveChanges();
        }

        public void Actualizar(Producto p)
        {
            _context.Productos.Update(p);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var p = _context.Productos.Find(id);
            if (p != null)
            {
                _context.Productos.Remove(p);
                _context.SaveChanges();
            }
        }
    }
}
