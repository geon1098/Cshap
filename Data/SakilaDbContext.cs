using CRUD_3.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_3.Data
{
    public class SakilaDbContext : DbContext
    {
        public SakilaDbContext(DbContextOptions<SakilaDbContext> options) : base(options)
        {
        }

        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().ToTable("language");
        }
    }
}