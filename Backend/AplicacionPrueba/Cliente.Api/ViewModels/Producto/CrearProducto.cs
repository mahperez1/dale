using System.ComponentModel.DataAnnotations;

namespace Cliente.Api.ViewModels.Producto
{
    public class CrearProducto
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener {1} caracteres máximos y {2} caracteres mínimo")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Valor unitario")]
        public string VlrProducto { get; set; }
    }
}