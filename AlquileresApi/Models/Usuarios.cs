using System.ComponentModel.DataAnnotations;

namespace AlquileresAPI.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Nombre { get; set; }

        [Required]
        public required string Correo { get; set; }

        [Required]
        public required string Contraseña { get; set; }
    }
}

