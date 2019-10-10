using Microsoft.EntityFrameworkCore;

namespace DBTimes.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}
        public DbSet<Ninja> Ninjas {get;set;}
    }
}