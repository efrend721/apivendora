using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("factura")]
    public class Factura
    {
        [Key]
        [Column("id_factura")]
        public int IdFactura { get; set; }

        [Column("caja")]
        public short Caja { get; set; }

        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Column("hora")]
        public TimeOnly Hora { get; set; }

        [Column("subtotal")]
        public int Subtotal { get; set; }

        [Column("cedula")]
        public int Cedula { get; set; }

        [Column("id_mesero")]
        public int IdMesero { get; set; }

        [Column("propina")]
        public int Propina { get; set; }
    }
}
