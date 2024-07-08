

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interface
{
    //Tạo interface để sử dụng AppDbContext
    public interface IAppDbContext
    {
        public DbSet<AppExample> Examples { get; set; }
        public DbSet<AppSample> Samples { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
