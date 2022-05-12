using Microsoft.EntityFrameworkCore;
using Product.Core.Entity;
using System.Linq;

namespace Product.Core.DbContext
{
    public class ProductDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        
        public DbSet<Products> Product { get; set; }
        public DbSet<Category> Category { get; set; }


        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    EntityRelationships(modelBuilder);
        //}

        //private void EntityRelationships(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new Configuration.ProductConfig());
        //    modelBuilder.ApplyConfiguration(new Configuration.CategoryConfig());
        //}
    }
}
