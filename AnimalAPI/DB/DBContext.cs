using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.DB
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
    }
}