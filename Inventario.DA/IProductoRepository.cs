using System.Collections.Generic;
using Inventario.MODEL;

namespace Inventario.DA
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
        void Agregar(Producto p);
        void Actualizar(Producto p);
        void Eliminar(int id);
    }
}
