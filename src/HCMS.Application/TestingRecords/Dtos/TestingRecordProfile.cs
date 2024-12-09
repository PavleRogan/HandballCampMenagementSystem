using AutoMapper;
using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.TestingRecords.Dtos
{
    internal class TestingRecordProfile : Profile
    {
        public TestingRecordProfile() {

            CreateMap<TestingRecord, TestingRecordDto>().ReverseMap() ;
        }
    }
}
