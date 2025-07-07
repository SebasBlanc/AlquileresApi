using System.ComponentModel.DataAnnotations;

namespace AlquileresAPI.Models
{
    public class Propiedad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Nombre { get; set; }

        public required string Direccion { get; set; }

        public required string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public required string ImagenUrl { get; set; }
    }
}
