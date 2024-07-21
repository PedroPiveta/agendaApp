using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
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
                .ForMember(dest => dest.DiasSemana, opt => opt.MapFrom(src => src.DiasSemana.ToString()));

            CreateMap<GetActivityDto, Activity>()
                .ForMember(dest => dest.DiasSemana, opt => opt.MapFrom(src => Enum.Parse<DiasSemana>(src.DiasSemana)));
        }
    }
}