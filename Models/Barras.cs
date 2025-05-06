using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("barras")]
    public class Barras
    {
        [Key]
        [Required(ErrorMessage = "El código de barras es obligatorio.")]
        [StringLength(24, ErrorMessage = "El código de barras no debe exceder los 24 caracteres.")]
        [Column("cdgo_barra")]
        public string? CodigoBarras { get; set; }

        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El código del producto debe ser mayor que cero.")]
        [Column("cdgo_producto")]
        public int CodigoProducto { get; set; }
    }
}
