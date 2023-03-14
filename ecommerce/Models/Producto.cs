using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public partial class Producto
    {
        public Producto()
        {
            CarritoCompras = new HashSet<CarritoCompra>();
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        public string Categoria { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Existencias { get; set; }

        public virtual ICollection<CarritoCompra> CarritoCompras { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
