using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("cajera")]
    public class Cajera
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("caja")]
        public short Caja { get; set; }

        [Column("tipo_usuario")]
        public string? TipoUsuario { get; set; }
    }
}
