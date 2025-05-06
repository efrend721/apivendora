using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("saldos")]
    public class Saldos
    {
        [Key]
        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Column("saldo_unid")]
        public int SaldoUnid { get; set; }

        [Column("saldo_frac")]
        public int SaldoFrac { get; set; }
    }
}
