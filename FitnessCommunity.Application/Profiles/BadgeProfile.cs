using AutoMapper;
using FitnessCommunity.Application.Commands.BadgeCommands;
using FitnessCommunity.Application.Dtos.BadgeDtos.Requests;
using FitnessCommunity.Application.Dtos.BadgeDtos.Responses;
using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Application.Profiles
{
    public class BadgeProfile : Profile
    {
        public BadgeProfile()
        {
            CreateMap<Badge, CreateBadgeRequest>().ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.IconUrl));

            CreateMap<Badge, UpdateBadgeRequest>().ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.IconUrl));

            CreateMap<Badge, GetAllBadgesResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Badge, GetBadgeByIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.IconUrl));

            CreateMap<CreateBadgeRequest,CreateBadgeCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.IconUrl));

            CreateMap<UpdateBadgeRequest, UpdateBadgeCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.IconUrl));

        }
    }
}
