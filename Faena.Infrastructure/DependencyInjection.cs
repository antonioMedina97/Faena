using Faena.Application.Common.Interfaces.Persistence;
using Faena.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace Faena.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {

        services.AddPersistence(configuration);
        
        return services;
    } 
    
    public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
    {

        services.AddDbContext<FaenaDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );
        
        services.AddScoped<IFlightRepository, FlightRepository>();
        
        return services;
    } 
}