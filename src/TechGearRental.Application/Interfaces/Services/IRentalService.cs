using TechGearRental.Application.DTOs;

namespace TechGearRental.Application.Interfaces.Services;

public interface IRentalService
{
    Task<RentalDto> CreateRentalAsync(CreateRentalDto request);
    Task<RentalDto> GetRentalByIdAsync(int id);
    Task<IReadOnlyList<RentalDto>> GetUserRentalsAsync(int userId);
}