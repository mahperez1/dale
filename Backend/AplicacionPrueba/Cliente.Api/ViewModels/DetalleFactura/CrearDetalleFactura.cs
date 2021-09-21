using System.ComponentModel.DataAnnotations;

namespace Cliente.Api.ViewModels.DetalleFactura
{
    public class CrearDetalleFactura
    {
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "Formato Guid incorrecto.")]
        public string IdProducto { get; set; }

        [Required]
        [Display(Name = "Numero de cedula")]
        public decimal Cantidad { get; set; }

        [Required]
        [Display(Name = "Valor Parcial")]
        public decimal ValorParcial { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "Formato Guid incorrecto.")]
        public string IdFactura { get; set; }
    }
}