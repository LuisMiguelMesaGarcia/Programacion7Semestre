using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public partial class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int IdProductoFk { get; set; }
        public int IdFacturaFk { get; set; }
        public int? Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }

        public virtual Factura IdFacturaFkNavigation { get; set; } = null!;
        public virtual Producto IdProductoFkNavigation { get; set; } = null!;
    }
}
