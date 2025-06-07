using Microsoft.EntityFrameworkCore;
using System;
using practiceEntityFramework.Entities.Products;

namespace AdventureWorksAPI.Data
{
    public class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options) : base(options) { }

        // Agrega aquí los DbSets de las tablas que usarás
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura el esquema y el nombre de la tabla
            //modelBuilder.Entity<Product>().ToTable("Product", schema: "Production");
        }
        
        public DbSet<Product> Product { get; set; }
    }
}

