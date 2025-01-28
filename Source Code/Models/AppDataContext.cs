using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SOFT40081_StarterCode.Models
{
    public class AppDataContext : IdentityDbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) :
            base(options)
                { }

        //Dbsets go here, add these and accompanying models before doing a database migration - see labs 5 and 6.

        public DbSet<Product> Products { get; set; }
    }
}
