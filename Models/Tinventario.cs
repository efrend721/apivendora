using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("tinventario")]
    public class Tinventario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        [StringLength(20, ErrorMessage = "El documento no debe exceder los 20 caracteres.")]
        [Column("documento")]
        public string? Documento { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "El ID del proveedor es obligatorio.")]
        [StringLength(11, ErrorMessage = "El ID del proveedor no debe exceder los 11 caracteres.")]
        [Column("id_proveedor")]
        public string? IdProveedor { get; set; }

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

        [Required(ErrorMessage = "El costo es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El costo no puede ser negativo.")]
        [Column("costo")]
        public int Costo { get; set; }

        [Required(ErrorMessage = "El código de transacción es obligatorio.")]
        [StringLength(6, ErrorMessage = "El código de transacción no debe exceder los 6 caracteres.")]
        [Column("cdgo_transaccion")]
        public string? CdgoTransaccion { get; set; }
    }
}
