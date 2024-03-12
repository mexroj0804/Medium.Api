using MediatR;
using Medium.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Medium.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(AutoMapperProfile));

        return services;
    }
}