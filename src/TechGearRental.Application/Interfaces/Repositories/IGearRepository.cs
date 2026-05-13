using TechGearRental.Domain.Entities;

namespace TechGearRental.Application.Interfaces.Repositories;

public interface IGearRepository : IGenericRepository<Gear>
{
    // Sadece kiralanabilir cihazları getiren özel bir metod
    Task<IReadOnlyList<Gear>> GetAvailableGearsAsync();
}