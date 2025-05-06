using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("producto")]
    public class Producto
    {
        [Key]
        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Column("cdgo_laboratorio")]
        public int CdgoLaboratorio { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Column("presentacion")]
        public string? Presentacion { get; set; }

        [Column("fraccion")]
        public short Fraccion { get; set; }

        [Column("costo")]
        public int Costo { get; set; }

        [Column("costo_frac")]
        public int CostoFrac { get; set; }

        [Column("precio")]
        public int Precio { get; set; }

        [Column("precio_frac")]
        public int PrecioFrac { get; set; }

        [Column("iva")]
        public short Iva { get; set; }

        [Column("estado")]
        public byte Estado { get; set; }
    }
}
