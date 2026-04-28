using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Test
{
    public class GestorInventarioTest
    {
        private GestorInventario gestor = new GestorInventario();

        // 1. AgregarProducto
        [Fact]
        public void AgregarProducto_DeberiaAgregarProducto()
        {
            var producto = new Producto
            {
                Id = 3,
                Nombre = "Mouse",
                Categoria = "Tecnología",
                Precio = 20,
                Stock = 5
            };

            gestor.AgregarProducto(producto);
            var lista = gestor.ObtenerProductos();

            Assert.Contains(lista, p => p.Id == 3);
        }

        // 2. EliminarProducto
        [Fact]
        public void EliminarProducto_DeberiaEliminarProducto()
        {
            gestor.EliminarProducto(1);
            var lista = gestor.ObtenerProductos();

            Assert.DoesNotContain(lista, p => p.Id == 1);
        }

        // 3. BuscarProductosPorNombre
        [Fact]
        public void BuscarProductosPorNombre_DeberiaRetornarCoincidencias()
        {
            var resultado = gestor.BuscarProductosPorNombre("laptop");

            Assert.NotEmpty(resultado);
        }

        // 4. BuscarProductosPorCategoria
        [Fact]
        public void BuscarProductosPorCategoria_DeberiaRetornarCategoriaCorrecta()
        {
            var resultado = gestor.BuscarProductosPorCategoria("Tecnología");

            Assert.All(resultado, p => Assert.Equal("Tecnología", p.Categoria));
        }

        // 5. ObtenerProductos
        [Fact]
        public void ObtenerProductos_DeberiaRetornarLista()
        {
            var lista = gestor.ObtenerProductos();

            Assert.NotNull(lista);
            Assert.True(lista.Count > 0);
        }
    }
}
