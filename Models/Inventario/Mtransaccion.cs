using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models.Inventario
{
    [Table("mtransaccion")]
    public class Mtransaccion
    {
        [Key]
        [Required(ErrorMessage = "El código de transacción es obligatorio.")]
        [StringLength(6, ErrorMessage = "El código no debe exceder los 6 caracteres.")]
        [Column("cdgo_transaccion")]
        public string? CdgoTransaccion { get; set; }

        [Required(ErrorMessage = "La descripción de la transacción es obligatoria.")]
        [StringLength(60, ErrorMessage = "La descripción no debe exceder los 60 caracteres.")]
        [Column("des_transaccion")]
        public string? DesTransaccion { get; set; }

        [Required(ErrorMessage = "El signo es obligatorio.")]
        [StringLength(2, ErrorMessage = "El signo no debe exceder los 2 caracteres.")]
        [Column("signo")]
        public string? Signo { get; set; }
    }
}
