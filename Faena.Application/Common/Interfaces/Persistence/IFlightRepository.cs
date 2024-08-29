using Faena.Domain.Flight;

namespace Faena.Application.Common.Interfaces.Persistence;

public interface IFlightRepository
{
    public Task<List<Flight>> GetAllFlights();

    public Task Add(Flight flight);
}