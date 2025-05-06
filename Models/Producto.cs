using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("producto")]
    public class Producto
    {
        [Key]
        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El código del producto debe ser mayor que cero.")]
        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Required(ErrorMessage = "El código del laboratorio es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El código del laboratorio debe ser mayor que cero.")]
        [Column("cdgo_laboratorio")]
        public int CdgoLaboratorio { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(60, ErrorMessage = "La descripción no debe exceder los 60 caracteres.")]
        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La presentación es obligatoria.")]
        [StringLength(60, ErrorMessage = "La presentación no debe exceder los 60 caracteres.")]
        [Column("presentacion")]
        public string? Presentacion { get; set; }

        [Required(ErrorMessage = "La fracción es obligatoria.")]
        [Range(0, short.MaxValue, ErrorMessage = "La fracción no puede ser negativa.")]
        [Column("fraccion")]
        public short Fraccion { get; set; }

        [Required(ErrorMessage = "El costo es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El costo no puede ser negativo.")]
        [Column("costo")]
        public int Costo { get; set; }

        [Required(ErrorMessage = "El costo fraccionado es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El costo fraccionado no puede ser negativo.")]
        [Column("costo_frac")]
        public int CostoFrac { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El precio no puede ser negativo.")]
        [Column("precio")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "El precio fraccionado es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El precio fraccionado no puede ser negativo.")]
        [Column("precio_frac")]
        public int PrecioFrac { get; set; }

        [Required(ErrorMessage = "El IVA es obligatorio.")]
        [Range(0, 100, ErrorMessage = "El IVA debe estar entre 0 y 100.")]
        [Column("iva")]
        public short Iva { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Range(0, 255, ErrorMessage = "El estado debe estar entre 0 y 255.")]
        [Column("estado")]
        public byte Estado { get; set; }
    }
}
