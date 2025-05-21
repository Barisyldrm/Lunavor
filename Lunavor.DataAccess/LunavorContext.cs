using Microsoft.EntityFrameworkCore;
using Lunavor.Entities;

namespace Lunavor.DataAccess
{
    public class LunavorContext : DbContext
    {
        public LunavorContext(DbContextOptions<LunavorContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User tablosu için ayarlar
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Username).IsUnique();
            });

            // Service tablosu için ayarlar
            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired();
            });

            // Portfolio tablosu için ayarlar
            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired();
            });

            // Blog tablosu için ayarlar
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Content).IsRequired();
            });
        }
    }
} 