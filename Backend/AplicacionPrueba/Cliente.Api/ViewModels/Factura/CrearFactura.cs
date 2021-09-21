using System.ComponentModel.DataAnnotations;

namespace Cliente.Api.ViewModels.Factura
{
    public class CrearFactura
    {
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "Formato Guid incorrecto.")]
        public string IdCliente { get; set; }

        [Required]
        [Display(Name = "Valor total")]
        public decimal ValorTotal { get; set; }
    }
}