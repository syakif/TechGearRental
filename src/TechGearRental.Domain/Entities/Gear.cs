using TechGearRental.Domain.Common;
using TechGearRental.Domain.Enums;

namespace TechGearRental.Domain.Entities;

public class Gear : BaseEntity
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public decimal PricePerDay { get; set; }
    public GearStatus Status { get; set; } = GearStatus.Available;

    // Foreign Key & Navigation
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}