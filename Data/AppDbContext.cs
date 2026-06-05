// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using TodoDatabase.Data;
namespace TodoDatabase.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}