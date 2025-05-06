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

        [Column("caja")]
        public short Caja { get; set; }

        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Column("hora")]
        public TimeOnly Hora { get; set; }

        [Column("valor_recogido")]
        public int ValorRecogido { get; set; }
    }
}
