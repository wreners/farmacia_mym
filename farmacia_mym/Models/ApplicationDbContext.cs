using Microsoft.EntityFrameworkCore;

namespace farmacia_mym.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } //entidad usuario
        // Agrega otras entidades aquí
    }
}
