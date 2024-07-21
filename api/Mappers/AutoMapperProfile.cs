using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Activity;
using api.Enums;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Activity, GetActivityDto>()
                .ForMember(dest => dest.DiasSemana, opt => opt.MapFrom(src => src.DiasSemana.Any() ? src.DiasSemana.Select(day => day.ToString()).ToList() : new List<string>()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId.ToString()));

            CreateMap<CreateActivityDto, Activity>()
                .ForMember(dest => dest.DiasSemana, opt => opt.MapFrom(src => src.DiasSemana.Select(day => Enum.Parse<DiasSemana>(day)).ToList()));

            CreateMap<Activity, CreateActivityDto>()
                .ForMember(dest => dest.DiasSemana, opt => opt.MapFrom(src => src.DiasSemana.Any() ? src.DiasSemana.Select(day => day.ToString()).ToList() : new List<string>()));
        }
    }
}
