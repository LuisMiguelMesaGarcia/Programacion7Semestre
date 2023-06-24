namespace ecommerce.ModelViews
{
    public class UsuariosMV
    {
        public int IdUsuario { get; set; }
        public string? Email { get; set; } = null!;
        public string? Estado { get; set; } = null!;
        public string? NombrePerso { get; set; } = null!;
        public string? ApellidoPerso{ get; set; } = null!;

    }
}
