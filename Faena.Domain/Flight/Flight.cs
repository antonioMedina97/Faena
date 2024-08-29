using System.ComponentModel.DataAnnotations.Schema;

namespace Faena.Domain.Flight;

public sealed class Flight
{
    private Flight(Guid id, string departureLocation, string arrivalLocation, string departureDateTime, string arrivalDateTime)
    {
        Id = id;
        DepartureLocation = departureLocation;
        ArrivalLocation = arrivalLocation;
        DepartureDateTime = departureDateTime;
        ArrivalDateTime = arrivalDateTime;
    }

    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")]
    public Guid Id { get; set; }
    [Column("departurelocation")]
    public string DepartureLocation { get; set; }
    [Column("arrivallocation")]
    public string ArrivalLocation { get; set; }
    [Column("departuredatetime")]
    public string DepartureDateTime { get; set; }
    [Column("arrivaldatetime")]
    public string ArrivalDateTime { get; set; }

    public static Flight Create(
        string departureLocation,
        string arrivalLocation,
        string departureDate,
        string arrivalDate)
    {
        return new(Guid.NewGuid(), departureLocation, arrivalLocation, departureDate, arrivalDate);
    }
}