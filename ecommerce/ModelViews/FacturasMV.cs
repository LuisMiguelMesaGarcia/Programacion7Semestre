namespace ecommerce.ModelViews
{
    public class FacturasMV
    {
        public int IdFactura { get; set; }
        public string vendedor { get; set; } = null!;
        public string cliente { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = null!;
    }
}
