using System;

namespace Entidades.Dominio
{
    public class Factura
    {
        public string IdFactura { get; set; }
        public string IdCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime FechaFactura { get; set; }
    }
}