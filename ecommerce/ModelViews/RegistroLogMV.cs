namespace ecommerce.ModelViews
{
    public class RegistroLogMV
    {
        public int IdRegistroLogin { get; set; }
        public string? Email { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; } = null!;
    }
}
