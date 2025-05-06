using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("defactura")]
    public class Defactura
    {
        [Required(ErrorMessage = "El ID de la factura es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la factura debe ser mayor que cero.")]
        [Column("id_factura")]
        public int IdFactura { get; set; }

        [Required(ErrorMessage = "El número de caja es obligatorio.")]
        [Range(1, short.MaxValue, ErrorMessage = "El número de caja debe ser mayor que cero.")]
        [Column("caja")]
        public short Caja { get; set; }

        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El código del producto debe ser mayor que cero.")]
        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Required(ErrorMessage = "La cantidad de unidades es obligatoria.")]
        [Range(0, byte.MaxValue, ErrorMessage = "Las unidades no pueden ser negativas.")]
        [Column("unid")]
        public byte Unid { get; set; }

        [Required(ErrorMessage = "La cantidad fraccionada es obligatoria.")]
        [Range(0, byte.MaxValue, ErrorMessage = "La fracción no puede ser negativa.")]
        [Column("frac")]
        public byte Frac { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a cero.")]
        [Column("precio")]
        public int Precio { get; set; }
    }
}
