using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models.Inventario
{
    [Table("proveedor")]
    public class Proveedor
    {
        [Key]
        [Required]
        [StringLength(11)]
        [Column("id_proveedor")]
        public string? IdProveedor { get; set; }

        [Required]
        [StringLength(60)]
        [Column("nombre")]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(60)]
        [Column("direccion")]
        public string? Direccion { get; set; }

        [Required]
        [StringLength(48)]
        [Column("tel")]
        public string? Tel { get; set; }

        [Required]
        [StringLength(60)]
        [Column("representante")]
        public string? Representante { get; set; }

        [Required]
        [StringLength(48)]
        [Column("tel_repre")]
        public string? TelRepre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [StringLength(60, ErrorMessage = "El correo no debe exceder los 60 caracteres.")]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido.")]
        [Column("email")]
        public string? Email { get; set; }

        [Required]
        [Range(0, 255)]
        [Column("estado")]
        public byte Estado { get; set; }
    }
}
