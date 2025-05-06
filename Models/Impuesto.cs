using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("impuesto")]
    public class Impuesto
    {
        [Required(ErrorMessage = "El ID de la factura es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la factura debe ser mayor que cero.")]
        [Column("id_factura")]
        public int IdFactura { get; set; }

        [Required(ErrorMessage = "La caja es obligatoria.")]
        [Range(1, short.MaxValue, ErrorMessage = "La caja debe ser mayor que cero.")]
        [Column("caja")]
        public short Caja { get; set; }

        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El código del producto debe ser mayor que cero.")]
        [Column("cdgo_producto")]
        public int CdgoProducto { get; set; }

        [Required(ErrorMessage = "El porcentaje es obligatorio.")]
        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100.")]
        [Column("porcentaje")]
        public int Porcentaje { get; set; }

        [Required(ErrorMessage = "La base del impuesto es obligatoria.")]
        [Range(0, int.MaxValue, ErrorMessage = "La base del impuesto no puede ser negativa.")]
        [Column("base")]
        public int Base { get; set; }

        [Required(ErrorMessage = "El valor del impuesto es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor del impuesto no puede ser negativo.")]
        [Column("valor_impto")]
        public int ValorImpto { get; set; }
    }
}
