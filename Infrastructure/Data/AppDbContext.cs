
using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    //Triễn khai interface IAppDbContext
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppExample> Examples { get; set; }
        public DbSet<AppSample> Samples { get; set; }

        //Triễn khai interface IAppDbContext để lưu CRUD 
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        //Tạo các vadation
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
