using AutoMapper;
using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Groups.Dtos
{
    public class GroupProfile : Profile
    {
        public GroupProfile() 
        { 
            CreateMap<Group,GroupDto>().ReverseMap();
        }
    }
}
