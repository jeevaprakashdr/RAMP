using Microsoft.EntityFrameworkCore;

namespace API.Db;

public sealed class ApiDatabaseContext : DbContext
{
    public ApiDatabaseContext(DbContextOptions<ApiDatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
}