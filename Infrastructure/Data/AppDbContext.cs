
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppExample> Examples { get; set; }
        public DbSet<AppSample> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Example
            modelBuilder.Entity<AppExample>()
                .Property(x => x.Title)
                .HasMaxLength(200);
            modelBuilder.Entity<AppExample>()
                .Property(x => x.Description)
                .HasMaxLength(200);
            //Sample
            modelBuilder.Entity<AppSample>()
                .Property(x => x.Title)
                .HasMaxLength(200);
            modelBuilder.Entity<AppSample>()
                .Property(x => x.Description)
                .HasMaxLength(200);

            //khóa ngoại
            modelBuilder.Entity<AppSample>()
                .HasOne(s => s.AppExample)
                .WithMany(s => s.samples)
                .HasForeignKey(s => s.ExampleId);
        }
    }
}
