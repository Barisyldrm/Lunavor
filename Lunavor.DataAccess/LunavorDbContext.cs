using Lunavor.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lunavor.DataAccess
{
    public class LunavorDbContext : DbContext
    {
        public LunavorDbContext(DbContextOptions<LunavorDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Role).IsRequired().HasMaxLength(20);
            });

            // User configuration
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Service configuration
            modelBuilder.Entity<Service>()
                .Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(100);

            // Portfolio configuration
            modelBuilder.Entity<Portfolio>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            // Blog configuration
            modelBuilder.Entity<Blog>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
} 