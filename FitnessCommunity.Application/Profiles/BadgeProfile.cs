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
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<Badge, UpdateBadgeRequest>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<Badge, GetAllBadgesResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Badge, GetBadgeByIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<UpdateBadgeRequest, UpdateBadgeCommand>()
                .ForMember(dest => dest.UpdateBadgeRequest,opt => opt.MapFrom(src => src));

            CreateMap<CreateBadgeRequest, CreateBadgeCommand>()
                .ForMember(dest => dest.CreateBadgeRequest, opt => opt.MapFrom(src => src));
        }
    }
}
