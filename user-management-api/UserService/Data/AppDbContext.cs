using Common.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace UserService.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Example DbSet
        public DbSet<User> Users { get; set; }
    }
}
