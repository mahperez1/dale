namespace Entidades.Dominio
{
    public class Producto
    {
        public string IdProducto { get; set; }
        public int CodProducto { get; set; }
        public string Nombre { get; set; }
        public decimal VlrProducto { get; set; }
        public bool IndicaEliminado { get; set; }
    }
}