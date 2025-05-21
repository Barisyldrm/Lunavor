using Lunavor.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lunavor.DataAccess.Contexts
{
    public class LunavorContext : DbContext
    {
        public LunavorContext(DbContextOptions<LunavorContext> options) : base(options)
        {
        }

        // Migration için parametresiz constructor
        public LunavorContext() { }

        public DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;initial Catalog=LunavorDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Icon).HasMaxLength(50);
                entity.Property(e => e.DisplayOrder).HasDefaultValue(0);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });
        }
    }
} 