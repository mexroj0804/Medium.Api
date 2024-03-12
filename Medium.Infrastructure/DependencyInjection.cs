using Medium.Application.Abstraction;
using Medium.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medium.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuretion)
    {
        services.AddDbContext<IAppDbContext, AppDbContext>(option =>
        {
            option.UseNpgsql(configuretion.GetConnectionString("DefaulConnection"));
        });

        return services;
    }
}