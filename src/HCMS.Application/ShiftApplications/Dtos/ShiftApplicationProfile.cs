using AutoMapper;
using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Dtos
{
    public class ShiftApplicationProfile : Profile
    {
        public ShiftApplicationProfile() 
        {
            CreateMap<ShiftApplication, ShiftApplicationDto>().ReverseMap();
        }
    }
}
