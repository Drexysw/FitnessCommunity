using AutoMapper;
using FitnessCommunity.Application.Dtos.UserBadgeDtos;
using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Application.Profiles
{
    public class UserBadgeProfile : Profile
    {
        public UserBadgeProfile()
        {
            CreateMap<AddBadgeToUserRequest, UserBadge>();
        }
    }
}
