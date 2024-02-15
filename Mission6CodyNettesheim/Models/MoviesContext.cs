using Microsoft.EntityFrameworkCore;

namespace Mission6CodyNettesheim.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options)
        {
        }

        public DbSet<Additions> Additions { get; set; } 

    }
}
 