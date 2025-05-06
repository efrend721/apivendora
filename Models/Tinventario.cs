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

        [Column("documento")]
        public string? Documento { get; set; }

        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Column("id_proveedor")]
        public string? IdProveedor { get; set; }

        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Column("unid")]
        public int Unid { get; set; }

        [Column("frac")]
        public int Frac { get; set; }

        [Column("costo")]
        public int Costo { get; set; }

        [Column("cdgo_transaccion")]
        public string? CdgoTransaccion { get; set; }
    }
}
