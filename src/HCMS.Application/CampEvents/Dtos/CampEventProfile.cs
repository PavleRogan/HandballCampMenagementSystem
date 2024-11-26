using AutoMapper;
using HCMS.Application.Groups.Dtos;
using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Dtos
{
    internal class CampEventProfile : Profile
    {
        public CampEventProfile()
        {
            CreateMap<CampEvent, CampEventDto>()
                .ForMember(dest => dest.CampEventId, opt => opt.MapFrom(src => src.CampEventId))  
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups)); 

            CreateMap<Group, GroupDto>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NumberOfMembers, opt => opt.MapFrom(src => src.NumberOfMembers))
                .ForMember(dest => dest.SeniorityLevel, opt => opt.MapFrom(src => src.SeniorityLevel))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<CampEventDto, CampEvent>()
                .ForMember(dest => dest.CampEventId, opt => opt.MapFrom(src => src.CampEventId))  
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups)); 


        }
    }
}
