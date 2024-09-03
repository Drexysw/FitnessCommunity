﻿using AutoMapper;
using FitnessCommunity.Application.Dtos.WorkoutDtos;
using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Application.Profiles
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, GetAllWorkoutResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level));

            CreateMap<Workout, GetWorkoutByIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level));

            CreateMap<CreateWorkoutRequest, Workout>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level));

            CreateMap<UpdateWorkoutRequest, Workout>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level));
        }
    }
}
