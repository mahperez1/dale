namespace Entidades.Dominio
{
    public class DetalleFactura
    {
        public string IdDetalleFactura { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorParcial { get; set; }
        public string IdFactura { get; set ;}
    }
}