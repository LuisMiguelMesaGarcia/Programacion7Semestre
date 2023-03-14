using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public partial class Persona
    {
        public Persona()
        {
            CarritoCompras = new HashSet<CarritoCompra>();
            FacturaIdClienteFkNavigations = new HashSet<Factura>();
            FacturaIdVendedorFkNavigations = new HashSet<Factura>();
            Publicidads = new HashSet<Publicidad>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPersona { get; set; }
        public string TipoDoc { get; set; } = null!;
        public string NumeroDoc { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Direccion { get; set; } = null!;

        public virtual ICollection<CarritoCompra> CarritoCompras { get; set; }
        public virtual ICollection<Factura> FacturaIdClienteFkNavigations { get; set; }
        public virtual ICollection<Factura> FacturaIdVendedorFkNavigations { get; set; }
        public virtual ICollection<Publicidad> Publicidads { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
