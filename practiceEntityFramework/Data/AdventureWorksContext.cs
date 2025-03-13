using Microsoft.EntityFrameworkCore;
using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Data
{
    public class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options) : base(options) { }

        // Agrega aquí los DbSets de las tablas que usarás
        public DbSet<Product> Products { get; set; }
    }
}

