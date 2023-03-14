using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int IdFactura { get; set; }
        public int IdVendedorFk { get; set; }
        public int IdClienteFk { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Persona IdClienteFkNavigation { get; set; } = null!;
        public virtual Persona IdVendedorFkNavigation { get; set; } = null!;
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
