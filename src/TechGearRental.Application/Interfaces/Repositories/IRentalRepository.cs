using TechGearRental.Domain.Entities;

namespace TechGearRental.Application.Interfaces.Repositories;

public interface IRentalRepository : IGenericRepository<Rental>
{
    // Belirtilen tarihler arasında cihazın başka bir kiralaması var mı kontrolü için
    Task<bool> HasOverlappingRentalAsync(int gearId, DateTime startDate, DateTime endDate);
}