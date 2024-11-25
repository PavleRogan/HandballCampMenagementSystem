using AutoMapper;
using HCMS.Application.Shifts.Commands.Update;
using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Dtos
{
    public class ShiftProfile : Profile
    {
        public ShiftProfile() 
        { 
            
            CreateMap<ShiftDto, Shift>().ReverseMap();
            CreateMap<UpdateShiftCommand, Shift>().ReverseMap();
        
        }
    }
}
