using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("mtransaccion")]
    public class Mtransaccion
    {
        [Key]
        [Column("cdgo_transaccion")]
        public string? CdgoTransaccion { get; set; }

        [Column("des_transaccion")]
        public string? DesTransaccion { get; set; }

        [Column("signo")]
        public string? Signo { get; set; }
    }
}
