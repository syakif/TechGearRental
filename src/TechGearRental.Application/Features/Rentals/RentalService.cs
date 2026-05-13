using AutoMapper;
using TechGearRental.Application.DTOs;
using TechGearRental.Application.Interfaces.Repositories;
using TechGearRental.Application.Interfaces.Services;
using TechGearRental.Domain.Entities;

namespace TechGearRental.Application.Features.Rentals;

public class RentalService : IRentalService
{
    private readonly IRentalRepository _rentalRepository;
    private readonly IGearRepository _gearRepository;
    private readonly IMapper _mapper;

    public RentalService(IRentalRepository rentalRepository, IGearRepository gearRepository, IMapper mapper)
    {
        _rentalRepository = rentalRepository;
        _gearRepository = gearRepository;
        _mapper = mapper;
    }

    public async Task<RentalDto> CreateRentalAsync(CreateRentalDto request)
    {
        // 1. Check if the gear exists
        var gear = await _gearRepository.GetByIdAsync(request.GearId);
        if (gear == null) throw new Exception("Gear not found");

        // 2. Business Logic: Check if the gear is available for these dates
        var isBusy = await _rentalRepository.HasOverlappingRentalAsync(request.GearId, request.StartDate, request.EndDate);
        if (isBusy) throw new Exception("Gear is already rented for the selected dates.");

        // 3. Calculate Price
        var days = (request.EndDate - request.StartDate).Days;
        if (days <= 0) days = 1;

        var rental = _mapper.Map<Rental>(request);
        rental.TotalPrice = days * gear.PricePerDay;

        // 4. Save
        var result = await _rentalRepository.AddAsync(rental);
        return _mapper.Map<RentalDto>(result);
    }

    public async Task<RentalDto> GetRentalByIdAsync(int id)
    {
        var rental = await _rentalRepository.GetByIdAsync(id);
        return _mapper.Map<RentalDto>(rental);
    }

    public async Task<IReadOnlyList<RentalDto>> GetUserRentalsAsync(int userId)
    {
        // This would typically involve a specific repository method FilterByUserId
        var rentals = await _rentalRepository.GetAllAsync();
        var userRentals = rentals.Where(x => x.UserId == userId).ToList();
        return _mapper.Map<IReadOnlyList<RentalDto>>(userRentals);
    }
}