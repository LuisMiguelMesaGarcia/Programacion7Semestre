namespace ecommerce.ModelViews
{
    public class PublicidadMV
    {
        public int IdPublicidad { get; set; }
        public string? cliente { get; set; }
        public string? TipoPublicidad { get; set; } = null!;
        public string? Imagen { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public decimal Precio { get; set; }
    }
}
