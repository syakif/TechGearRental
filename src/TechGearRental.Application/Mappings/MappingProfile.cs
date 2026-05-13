using AutoMapper;
using TechGearRental.Application.DTOs;
using TechGearRental.Domain.Entities;

namespace TechGearRental.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Gear Mappings
        CreateMap<Gear, GearDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<CreateGearDto, Gear>();

        // Rental Mappings
        CreateMap<Rental, RentalDto>()
            .ForMember(dest => dest.GearModel, opt => opt.MapFrom(src => $"{src.Gear.Brand} {src.Gear.Model}"))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<CreateRentalDto, Rental>();
    }
}