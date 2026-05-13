using TechGearRental.Domain.Common;

namespace TechGearRental.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Navigation Property
    public ICollection<Gear> Gears { get; set; } = new List<Gear>();
}