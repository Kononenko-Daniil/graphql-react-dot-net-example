using api.Models;
using GreenDonut;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace api.Contexts
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<Note> Notes { get; set; }

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"), options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().ToTable("Notes", "test");
            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.CreatorId).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
