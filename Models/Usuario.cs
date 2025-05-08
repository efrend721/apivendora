using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(20, ErrorMessage = "El nombre de usuario no debe exceder 20 caracteres.")]
        [Column("tipo_usuario")]
        public string? Tipo_ususario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(12, ErrorMessage = "La contraseña no debe exceder 12 caracteres.")]
        [Column("pass")]
        public string? Pass { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(20, ErrorMessage = "El nombre no debe exceder 20 caracteres.")]
        [Column("nombre_user")]
        public string? NombreUser { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(20, ErrorMessage = "El apellido no debe exceder 20 caracteres.")]
        [Column("apellido_user")]
        public string? ApellidoUser { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [StringLength(20, ErrorMessage = "El teléfono no debe exceder 20 caracteres.")]
        [Column("tel")]
        public string? Tel { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [StringLength(20, ErrorMessage = "El correo no debe exceder 20 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [Column("email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El nivel de acceso es obligatorio.")]
        [Range(0, 255, ErrorMessage = "El nivel de acceso debe estar entre 0 y 255.")]
        [Column("nivel_acceso")]
        public byte NivelAcceso { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Range(0, 255, ErrorMessage = "El estado debe estar entre 0 y 255.")]
        [Column("estado")]
        public byte Estado { get; set; }
    }
}
