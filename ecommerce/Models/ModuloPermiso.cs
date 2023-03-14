using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public partial class ModuloPermiso
    {
        public int IdModuloPermiso { get; set; }
        public string Modulo { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Permiso { get; set; } = null!;
    }
}
