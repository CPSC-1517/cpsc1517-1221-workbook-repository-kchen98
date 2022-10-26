using Microsoft.EntityFrameworkCore;
using WestwindSystem.Entities;

namespace WestwindSystem.DAL
{
    internal class WestwindContext : DbContext /*(alternative don't need using) Microsoft.EntityFrameworkCore.DbContext*/
    {
        public WestwindContext(DbContextOptions<WestwindContext> options) : base(options)
        {
           
        }

        public DbSet<BuildVersion> BuildVersions => Set<BuildVersion>();

        public DbSet<Category> Categories => Set<Category>();
    }
}
