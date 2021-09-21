using System.ComponentModel.DataAnnotations;

namespace Cliente.Api.ViewModels.Producto
{
    public class ActualizarProducto
    {
        [Required]
        [DataType(DataType.Text)]
        //[RegularExpression("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "Formato Guid incorrecto.")]
        public string idProducto { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener {1} caracteres máximos y {2} caracteres mínimo")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Valor unitario")]
        public decimal vlrProducto { get; set; }

        [Display(Name = "Estado Eliminado")]
        public bool indicaEliminado { get; set; }
    }
}