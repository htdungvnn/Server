using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DataContext;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options):base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}