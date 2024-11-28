using AutoMapper;
using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Admins.Dtos
{
    internal class AdminsProfile : Profile
    {
        public AdminsProfile() 
        { 
            CreateMap<Admin, AdminDto>().ReverseMap();
        }
    }
}
