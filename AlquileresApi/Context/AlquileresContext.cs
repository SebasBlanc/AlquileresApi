using AlquileresAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlquileresAPI.Context
{
    public class AlquileresContext : DbContext
    {
        public AlquileresContext(DbContextOptions<AlquileresContext> options)
            : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
    }
}

