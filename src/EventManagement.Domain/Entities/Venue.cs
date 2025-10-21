using EventManagement.Domain.Guards;
using System.Diagnostics.CodeAnalysis;

namespace EventManagement.Domain.Entities;

/// <summary>
/// Representa o local onde um evento será realizado.
/// </summary>
public class Venue
{
    private string _parkingInfo = string.Empty;

    public int VenueId { get; }
    public string Name { get; }
    public string Address { get; }
    public int Capacity { get; }
    public string? Description { get; private set; }

    /// <summary>
    /// Informações sobre estacionamento. Aceita null mas retorna string vazia.
    /// </summary>
    [AllowNull]
    public string ParkingInfo
    {
        get => _parkingInfo;
        set => _parkingInfo = value ?? string.Empty;
    }

    /// <summary>
    /// Local padrão para eventos online.
    /// </summary>
    public static Venue Default => new(1, "Online Event", "Virtual", 10000);

    public Venue(int venueId, string name, string address, int capacity)
    {
        // Valida VenueId
        Guard.AgainstNegativeOrZero(venueId, nameof(venueId));

        // Valida Name
        Guard.AgainstNull(ref name, nameof(name));

        // Valida Address
        Guard.AgainstNull(ref address, nameof(address));
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address cannot be empty or whitespace.", nameof(address));

        // Valida Capacity
        Guard.AgainstNegativeOrZero(capacity, nameof(capacity));

        VenueId = venueId;
        Name = name;
        Address = address;
        Capacity = capacity;
    }

    /// <summary>
    /// Define a descrição do local.
    /// </summary>
    public void SetDescription(string? description)
    {
        if (Guard.TryParseNonEmpty(description, out string? validDescription))
        {
            Description = validDescription;
        }
        else
        {
            Description = null;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Venue other)
            return false;

        return VenueId == other.VenueId;
    }

    public override int GetHashCode()
    {
        return VenueId.GetHashCode();
    }

    public override string ToString()
    {
        return $"Venue [Id: {VenueId}, Name: {Name}, Address: {Address}, " +
               $"Capacity: {Capacity}, Description: {Description ?? "N/A"}]";
    }
}