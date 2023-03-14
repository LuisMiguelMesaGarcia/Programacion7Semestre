using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public partial class CarritoCompra
    {
        public int IdCarrito { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdProductoFk { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Persona IdPersonaFkNavigation { get; set; } = null!;
        public virtual Producto IdProductoFkNavigation { get; set; } = null!;
    }
}
