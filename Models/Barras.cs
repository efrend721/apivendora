using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("barras")]
    public class Barras
    {
        [Key]
        [Column("cdgo_barra")]
        public string? CdgoBarra { get; set; }

        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }
    }
}
