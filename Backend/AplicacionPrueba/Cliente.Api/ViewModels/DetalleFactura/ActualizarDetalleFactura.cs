using System.ComponentModel.DataAnnotations;

namespace Cliente.Api.ViewModels.DetalleFactura
{
    public class ActualizarDetalleFactura
    {
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "Formato Guid incorrecto.")]
        public string IdDetalleFactura { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "Formato Guid incorrecto.")]
        public string IdProducto { get; set; }

        [Required]
        [Display(Name = "Numero de cedula")]
        public string Cantidad { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener {1} caracteres máximos y {2} caracteres mínimo")]
        [Display(Name = "Valor Parcial")]
        public string ValorParcial { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "Formato Guid incorrecto.")]
        public string IdFactura { get; set; }
    }
}