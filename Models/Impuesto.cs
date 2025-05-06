using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Models
{
    [Table("impuesto")]
    [Keyless]
    public class Impuesto
    {
        [Column("id_factura")]
        public int IdFactura { get; set; }

        [Column("caja")]
        public short Caja { get; set; }

        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Column("porcentaje")]
        public int Porcentaje { get; set; }

        [Column("base")]
        public int Base { get; set; }

        [Column("valor_impto")]
        public int ValorImpto { get; set; }
    }
}
