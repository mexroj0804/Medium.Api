using Medium.Application.Abstraction;
using Medium.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medium.Infrastructure.Persistance;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }
}