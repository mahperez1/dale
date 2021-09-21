using System.ComponentModel.DataAnnotations;

namespace Cliente.Api.ViewModels.Cliente
{
    public class ActualizarCliente
    {
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "Formato Guid incorrecto.")]
        public string IdCliente { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener {1} caracteres máximos y {2} caracteres mínimo")]
        [Display(Name = "Numero de cedula")]
        public string Cedula { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener {1} caracteres máximos y {2} caracteres mínimo")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 10, MinimumLength = 7, ErrorMessage = "El campo {0} debe tener {1} caracteres máximos y {2} caracteres mínimo")]
        [Display(Name = "Numero de telefono")]
        public string NumeroTelefono { get; set; }

        [Required]
        [Display(Name = "Estado Eliminado")]
        public bool IndicaEliminado { get; set; }
    }
}