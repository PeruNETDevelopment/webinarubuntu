using System.Reflection;
using Microsoft.EntityFrameworkCore;

public class WebinarDbContext : DbContext
{
    public WebinarDbContext(DbContextOptions<WebinarDbContext> options)
        :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}