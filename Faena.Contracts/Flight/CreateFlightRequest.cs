namespace Faena.Contracts.Flight;

public record CreateFlightRequest
(
    string DepartureLocation,
    string ArrivalLocation,
    string DepartureDate,
    string ArrivalDate
);