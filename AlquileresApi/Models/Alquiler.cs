using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AlquileresAPI.Models
{
    public class Alquiler
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int PropiedadId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        [ForeignKey("UsuarioId")]
        public required Usuarios Usuario { get; set; }

        [ForeignKey("PropiedadId")]
        public required Propiedad Propiedad { get; set; }
    }
}

