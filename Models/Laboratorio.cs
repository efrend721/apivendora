using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("laboratorio")]
    public class Laboratorio
    {
        [Key]
        [Required(ErrorMessage = "El código del laboratorio es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El código del laboratorio debe ser mayor que cero.")]
        [Column("cdgo_laboratorio")]
        public int CdgoLaboratorio { get; set; }

        [Required(ErrorMessage = "El nombre del laboratorio es obligatorio.")]
        [StringLength(60, ErrorMessage = "El nombre no debe exceder los 60 caracteres.")]
        [Column("nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Range(0, 255, ErrorMessage = "El estado debe estar entre 0 y 255.")]
        [Column("estado")]
        public int Estado { get; set; }
    }
}
