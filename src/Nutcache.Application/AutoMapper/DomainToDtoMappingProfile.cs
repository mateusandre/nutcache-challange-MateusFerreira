using AutoMapper;
using Nutcache.Application.DTO;
using Nutcache.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutcache.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Employee, EmployeeWithIdDto>();
        }
    }
}
