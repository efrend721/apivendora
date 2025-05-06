using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("formapago")]
    public class Formapago
    {
        [Required(ErrorMessage = "El ID de la factura es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la factura debe ser mayor que cero.")]
        [Column("id_factura")]
        public int IdFactura { get; set; }

        [Required(ErrorMessage = "La caja es obligatoria.")]
        [Range(1, short.MaxValue, ErrorMessage = "El número de caja debe ser mayor que cero.")]
        [Column("caja")]
        public short Caja { get; set; }

        [Required(ErrorMessage = "La forma de pago es obligatoria.")]
        [Range(1, short.MaxValue, ErrorMessage = "El ID de forma de pago debe ser mayor que cero.")]
        [Column("id_formapago")]
        public short IdFormapago { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor no puede ser negativo.")]
        [Column("valor")]
        public int Valor { get; set; }

        [Required(ErrorMessage = "El valor recibido es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor recibido no puede ser negativo.")]
        [Column("recibido")]
        public int Recibido { get; set; }
    }
}
