using Faena.Application.Common.Interfaces.Persistence;
using Faena.Domain.Flight;
using Microsoft.EntityFrameworkCore;

namespace Faena.Infrastructure.Persistence;

public class FlightRepository(FaenaDbContext dbContext) : IFlightRepository
{
    public async Task<List<Flight>> GetAllFlights()
    {
        return await dbContext.Flights.ToListAsync();
    }

    public async Task Add(Flight flight)
    {
        await dbContext.Flights.AddAsync(flight);
        await dbContext.SaveChangesAsync();
    }
}