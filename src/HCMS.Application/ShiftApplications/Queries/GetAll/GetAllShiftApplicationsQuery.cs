using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Seasons.Dtos;
using HCMS.Application.Seasons.Queries.GetAllSeasons;
using HCMS.Application.ShiftApplications.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Queries.GetAll
{
    public class GetAllShiftApplicationsQuery :IRequest<IEnumerable<ShiftApplicationDto>>
    {
       
    }
}
