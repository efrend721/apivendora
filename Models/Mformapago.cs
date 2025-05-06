using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("mformapago")]
    public class Mformapago
    {
        [Key]
        [Required(ErrorMessage = "El ID de la forma de pago es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID debe ser mayor que cero.")]
        [Column("id_formapago")]
        public int IdFormapago { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(60, ErrorMessage = "La descripción no debe exceder los 60 caracteres.")]
        [Column("descripcion")]
        public string? Descripcion { get; set; }
    }
}
