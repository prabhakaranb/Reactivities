using AutoMapper;
using Domain;

namespace Application.Activities;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, Activity>();
        // CreateMap<Activity, ActivityDto>()
        //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        //     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        //     .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        //     .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
        //     .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
        //     .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
        //     .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue));
    }
}
