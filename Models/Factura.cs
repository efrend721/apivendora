using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("factura")]
    public class Factura
    {
        [Key]
        [Column("id_factura")]
        public int IdFactura { get; set; }

        [Required(ErrorMessage = "La caja es obligatoria.")]
        [Range(1, short.MaxValue, ErrorMessage = "La caja debe ser mayor que cero.")]
        [Column("caja")]
        public short Caja { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "La hora es obligatoria.")]
        [Column("hora")]
        public TimeOnly Hora { get; set; }

        [Required(ErrorMessage = "El subtotal es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El subtotal debe ser mayor o igual a cero.")]
        [Column("subtotal")]
        public int Subtotal { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cédula debe ser mayor que cero.")]
        [Column("cedula")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "El ID del mesero es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del mesero debe ser mayor que cero.")]
        [Column("id_mesero")]
        public int IdMesero { get; set; }

        [Required(ErrorMessage = "La propina es obligatoria.")]
        [Range(0, int.MaxValue, ErrorMessage = "La propina debe ser mayor o igual a cero.")]
        [Column("propina")]
        public int Propina { get; set; }
    }
}
