using AutoMapper;
using FitnessCommunity.Application.Commands.ExerciseCommands;
using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests;
using FitnessCommunity.Application.Dtos.ExerciseDtos.Responses;
using FitnessCommunity.Application.Queries.ExerciseQueries;
using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Application.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<GetAllExerciseResponse,Exercise>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl))
                .ForMember(dest => dest.MuscleGroup, opt => opt.MapFrom(src => src.MuscleGroup));

            CreateMap<GetByIdExerciseResponse,Exercise>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl))
                .ForMember(dest => dest.Sets, opt => opt.MapFrom(src => src.Sets))
                .ForMember(dest => dest.Repetitions, opt => opt.MapFrom(src => src.Repetitions))
                .ForMember(dest => dest.MuscleGroup, opt => opt.MapFrom(src => src.MuscleGroup));

            CreateMap<Exercise,CreateExerciseRequest>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl))
                .ForMember(dest => dest.Sets, opt => opt.MapFrom(src => src.Sets))
                .ForMember(dest => dest.Repetitions, opt => opt.MapFrom(src => src.Repetitions))
                .ForMember(dest => dest.MuscleGroup, opt => opt.MapFrom(src => src.MuscleGroup));

            CreateMap<Exercise, UpdateExerciseRequest>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl))
                .ForMember(dest => dest.Sets, opt => opt.MapFrom(src => src.Sets))
                .ForMember(dest => dest.Repetitions, opt => opt.MapFrom(src => src.Repetitions))
                .ForMember(dest => dest.MuscleGroup, opt => opt.MapFrom(src => src.MuscleGroup));

            CreateMap<CreateExerciseRequest, CreateExerciseCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl))
                .ForMember(dest => dest.Sets, opt => opt.MapFrom(src => src.Sets))
                .ForMember(dest => dest.Repetitions, opt => opt.MapFrom(src => src.Repetitions))
                .ForMember(dest => dest.MuscleGroup, opt => opt.MapFrom(src => src.MuscleGroup));

            CreateMap<UpdateExerciseRequest, UpdateExerciseCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl))
                .ForMember(dest => dest.Sets, opt => opt.MapFrom(src => src.Sets))
                .ForMember(dest => dest.Repetitions, opt => opt.MapFrom(src => src.Repetitions))
                .ForMember(dest => dest.MuscleGroup, opt => opt.MapFrom(src => src.MuscleGroup));

        }
    }
}
