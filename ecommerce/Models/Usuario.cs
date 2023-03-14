using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ResgitroLogins = new HashSet<ResgitroLogin>();
        }

        public int IdUsuario { get; set; }
        public int IdPersonaFk { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual Persona IdPersonaFkNavigation { get; set; } = null!;
        public virtual ICollection<ResgitroLogin> ResgitroLogins { get; set; }
    }
}
