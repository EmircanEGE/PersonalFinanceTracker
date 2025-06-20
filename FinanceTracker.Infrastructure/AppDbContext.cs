using FinanceTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Istanbul'");
            });
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<User> Users { get; set; }
    }
}