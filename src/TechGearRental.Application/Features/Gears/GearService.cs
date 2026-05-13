using AutoMapper;
using TechGearRental.Application.DTOs;
using TechGearRental.Application.Interfaces.Repositories;
using TechGearRental.Application.Interfaces.Services;
using TechGearRental.Domain.Entities;

namespace TechGearRental.Application.Features.Gears;

public class GearService : IGearService
{
	private readonly IGearRepository _gearRepository;
	private readonly IMapper _mapper;

	public GearService(IGearRepository gearRepository, IMapper mapper)
	{
		_gearRepository = gearRepository;
		_mapper = mapper;
	}

	public async Task<GearDto> GetGearByIdAsync(int id)
	{
		var gear = await _gearRepository.GetByIdAsync(id);
		return _mapper.Map<GearDto>(gear);
	}

	public async Task<IReadOnlyList<GearDto>> GetAllGearsAsync()
	{
		var gears = await _gearRepository.GetAllAsync();
		return _mapper.Map<IReadOnlyList<GearDto>>(gears);
	}

	public async Task<GearDto> AddGearAsync(CreateGearDto request)
	{
		var gear = _mapper.Map<Gear>(request);
		var createdGear = await _gearRepository.AddAsync(gear);
		return _mapper.Map<GearDto>(createdGear);
	}
}