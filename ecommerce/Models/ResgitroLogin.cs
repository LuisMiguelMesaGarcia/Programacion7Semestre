using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public partial class ResgitroLogin
    {
        public int IdRegistroLogin { get; set; }
        public int IdUsuarioFk { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; } = null!;

        public virtual Usuario IdUsuarioFkNavigation { get; set; } = null!;
    }
}
