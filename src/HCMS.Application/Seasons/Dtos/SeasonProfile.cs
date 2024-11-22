using AutoMapper;
using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Dtos
{
    public class SeasonProfile : Profile
    {
        public SeasonProfile() 
        { 
        
            CreateMap<Season, SeasonDto>();
        
        }
    }
}
