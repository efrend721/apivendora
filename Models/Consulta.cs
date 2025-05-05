using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("consulta")]
    public class Consulta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Column("unid")]
        public int Unid { get; set; }

        [Column("frac")]
        public int Frac { get; set; }
    }
}
