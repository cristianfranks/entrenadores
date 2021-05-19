using Microsoft.EntityFrameworkCore;

namespace entrenadores.Models
{
    public class EntrenadorContext : DbContext
    {
        public DbSet<Entrenador>  Entrenadores { get; set; }
        public DbSet<Pueblo> Pueblos { get; set; }

        public EntrenadorContext(DbContextOptions dco) : base(dco){
            
        }
    }
}