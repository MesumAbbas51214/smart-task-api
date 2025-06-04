using Microsoft.EntityFrameworkCore;
using SmartTaskApi.Models;

namespace SmartTaskApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
