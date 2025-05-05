using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Models
{
    [Table("defactura")]
    [Keyless]
    public class Defactura
    {
        [Column("id_factura")]
        public int IdFactura { get; set; }

        [Column("caja")]
        public short Caja { get; set; }

        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Column("unid")]
        public byte Unid { get; set; }

        [Column("frac")]
        public byte Frac { get; set; }

        [Column("precio")]
        public int Precio { get; set; }
    }
}
