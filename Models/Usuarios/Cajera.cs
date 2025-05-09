using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models.Usuarios
{
    [Table("cajera")]
    public class Cajera
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de caja es obligatorio.")]
        [Range(1, short.MaxValue, ErrorMessage = "El número de caja debe ser mayor que cero.")]
        [Column("caja")]
        public short Caja { get; set; }

        [Required(ErrorMessage = "El tipo de usuario es obligatorio.")]
        [StringLength(20, ErrorMessage = "El tipo de usuario no debe exceder los 20 caracteres.")]
        [Column("tipo_usuario")]
        public string? TipoUsuario { get; set; }
    }
}
