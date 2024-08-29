using Faena.Domain.Flight;
using Microsoft.EntityFrameworkCore;

namespace Faena.Infrastructure.Persistence;

public class FaenaDbContext(DbContextOptions<FaenaDbContext> options) : DbContext(options)
{
    public DbSet<Flight> Flights { get; set; }
}