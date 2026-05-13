using TechGearRental.Application.DTOs;

namespace TechGearRental.Application.Interfaces.Services;

public interface IGearService
{
    Task<GearDto> GetGearByIdAsync(int id);
    Task<IReadOnlyList<GearDto>> GetAllGearsAsync();
    Task<GearDto> AddGearAsync(CreateGearDto request);
}