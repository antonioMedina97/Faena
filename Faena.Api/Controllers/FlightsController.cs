using Faena.Application.Common.Interfaces.Persistence;
using Faena.Contracts.Flight;
using Faena.Domain.Flight;
using Microsoft.AspNetCore.Mvc;

namespace Faena.Api.Controllers;

[Route("[controller]")]
public class FlightsController(IFlightRepository flightRepository) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> ListFlights()
    {
        var flights = await flightRepository.GetAllFlights();
        
        return Ok(flights);
    }

    [HttpPost]
    public async Task<IActionResult> AddFlight(CreateFlightRequest request)
    {
        //Todo refactor to call repository in Application layer
       await flightRepository.Add(MapRequestToFlight(request));

       return Ok("Created");
    }

    private Flight MapRequestToFlight(CreateFlightRequest request)
    {
        return Flight.Create(request.DepartureLocation, request.ArrivalLocation, request.DepartureDate,
            request.ArrivalDate);
    }
}