using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Models
{
    [Table("formapago")]
    [Keyless]
    public class Formapago
    {
        [Column("id_factura")]
        public int IdFactura { get; set; }

        [Column("caja")]
        public short Caja { get; set; }

        [Column("id_formapago")]
        public short IdFormaPago { get; set; }

        [Column("valor")]
        public int Valor { get; set; }

        [Column("recibido")]
        public int Recibido { get; set; }
    }
}
