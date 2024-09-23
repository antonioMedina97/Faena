using Faena.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Faena.Api;

public static class MigrationsHandler
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        try
        {
            Console.WriteLine("Applying migrations...");
            var scope = app.ApplicationServices.CreateScope();
            using FaenaDbContext dbContext = scope.ServiceProvider.GetRequiredService<FaenaDbContext>();
            dbContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
            throw;
        }
    } 
}