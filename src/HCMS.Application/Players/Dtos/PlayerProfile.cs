using AutoMapper;
using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Players.Dtos
{
    internal class PlayerProfile : Profile
    {
        public PlayerProfile() 
        {
            CreateMap<Player, PlayerDto>();

            CreateMap<PlayerDto, Player>();
        }
    }
}
