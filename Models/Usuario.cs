using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("usuario")] // Opcional: forzamos que se mapee a la tabla "usuario"
    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("tipo_usuario")]
        public string? TipoUsuario { get; set; }

        public string? Pass { get; set; }

        [Column("nombre_user")]
        public string? NombreUser { get; set; }

        [Column("apellido_user")]
        public string? ApellidoUser { get; set; }

        public string? Tel { get; set; }
        public string? Email { get; set; }

        [Column("nivel_acceso")]
        public byte NivelAcceso { get; set; }

        public byte Estado { get; set; }
    }
}
