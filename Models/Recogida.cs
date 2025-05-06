using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("recogida")]
    public class Recogida
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La caja es obligatoria.")]
        [Range(1, short.MaxValue, ErrorMessage = "El número de caja debe ser mayor que cero.")]
        [Column("caja")]
        public short Caja { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "La hora es obligatoria.")]
        [Column("hora")]
        public TimeOnly Hora { get; set; }

        [Required(ErrorMessage = "El valor recogido es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor recogido no puede ser negativo.")]
        [Column("valor_recogido")]
        public int ValorRecogido { get; set; }
    }
}
