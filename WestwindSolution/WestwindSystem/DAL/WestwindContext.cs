using Microsoft.EntityFrameworkCore;
using WestwindSystem.Entities;

namespace WestwindSystem.DAL
{
    // DbContext is for accessing which database to use
    internal class WestwindContext : DbContext /*(alternative don't need using) Microsoft.EntityFrameworkCore.DbContext*/
    {
        // Parameterized constructor that allows for Dependency Injection
        public WestwindContext(DbContextOptions<WestwindContext> options) : base(options)
        {
           
        }

        // Need DbSet for each entities to access the table with the same name in the database
        public DbSet<BuildVersion> BuildVersions => Set<BuildVersion>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Product> Products => Set<Product>();
    }
}
