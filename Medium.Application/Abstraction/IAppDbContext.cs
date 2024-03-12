using Medium.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medium.Application.Abstraction;

public interface IAppDbContext
{
    public DbSet<User> Users { get; set; }

    Task<int> SavechangesAsync(CancellationToken cancellationToken = default);
}