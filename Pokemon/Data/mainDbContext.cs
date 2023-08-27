using Microsoft.EntityFrameworkCore;
using Pokemon.Models.Domain;

namespace Pokemon.Data
{
    public class mainDbContext : DbContext
    {
        public mainDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Users> pUsers { get; set; }
    }
}
