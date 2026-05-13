using TechGearRental.Domain.Common;
using TechGearRental.Domain.Enums;

namespace TechGearRental.Domain.Entities;

public class Rental : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public RentalStatus Status { get; set; } = RentalStatus.Active;

    // Foreign Keys
    public int GearId { get; set; }
    public Gear Gear { get; set; } = null!;

    public int UserId { get; set; } // Identity kullanacaksan string veya int seçebilirsin
    // public User User { get; set; } // Daha sonra eklenebilir
}