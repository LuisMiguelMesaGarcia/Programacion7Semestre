namespace ecommerce.ModelViews
{
    public class CarritoMV
    {
        public int IdCarrito { get; set; }
        public string? Cliente { get; set; }
        public string? Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
