using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("mformapago")]
    public class Mformapago
    {
        [Key]
        [Column("id_formapago")]
        public int IdFormapago { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }
    }
}
