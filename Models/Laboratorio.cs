using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("laboratorio")]
    public class Laboratorio
    {
        [Key]
        [Column("cdgo_laboratorio")]
        public int CdgoLaboratorio { get; set; }

        [Column("nombre")]
        public string? Nombre { get; set; }

        [Column("estado")]
        public int Estado { get; set; }
    }
}
