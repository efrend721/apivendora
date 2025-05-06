using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("consulta")]
    public class Consulta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El código del producto debe ser mayor que cero.")]
        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Required(ErrorMessage = "La cantidad de unidades es obligatoria.")]
        [Range(0, int.MaxValue, ErrorMessage = "Las unidades no pueden ser negativas.")]
        [Column("unid")]
        public int Unid { get; set; }

        [Required(ErrorMessage = "La cantidad fraccionada es obligatoria.")]
        [Range(0, int.MaxValue, ErrorMessage = "La fracción no puede ser negativa.")]
        [Column("frac")]
        public int Frac { get; set; }
    }
}
