using System;
using System.ComponentModel.DataAnnotations;

namespace Inventario.MODEL
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(1, 9999999, ErrorMessage = "El precio debe estar entre 1 y 9,999,999")]
        public double Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un número no negativo")]
        public int Stock { get; set; } = 0;

        public bool Activo { get; set; } = true;

        public DateTime FechaIngreso { get; set; } = DateTime.Now;
    }
}
