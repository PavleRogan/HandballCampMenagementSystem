using AutoMapper;
using HCMS.Application.Coaches.Commands.Update;
using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Coaches.Dtos
{
    internal class CoachesProfile : Profile
    {
        public CoachesProfile() 
        {
            CreateMap<CoachDto, Coach>().ReverseMap();
            CreateMap<UpdateCoachCommand, Coach>().ReverseMap();


        }
    }
}
