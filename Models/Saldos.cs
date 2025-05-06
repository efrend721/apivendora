using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("saldos")]
    public class Saldos
    {
        [Key]
        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El código del producto debe ser mayor que cero.")]
        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Required(ErrorMessage = "El saldo en unidades es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El saldo en unidades no puede ser negativo.")]
        [Column("saldo_unid")]
        public int SaldoUnid { get; set; }

        [Required(ErrorMessage = "El saldo fraccionado es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El saldo fraccionado no puede ser negativo.")]
        [Column("saldo_frac")]
        public int SaldoFrac { get; set; }
    }
}
