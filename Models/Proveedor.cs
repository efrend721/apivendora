using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apivendora.Models
{
    [Table("proveedor")]
    public class Proveedor
    {
        [Key]
        [Column("id_proveedor")]
        public string? IdProveedor { get; set; }

        [Column("nombre")]
        public string? Nombre { get; set; }

        [Column("direccion")]
        public string? Direccion { get; set; }

        [Column("tel")]
        public string? Tel { get; set; }

        [Column("representante")]
        public string? Representante { get; set; }

        [Column("tel_repre")]
        public string? TelRepre { get; set; }

        [Column("estado")]
        public byte Estado { get; set; }
    }
}
