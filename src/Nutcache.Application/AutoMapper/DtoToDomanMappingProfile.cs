using AutoMapper;
using Nutcache.Application.Commands;
using Nutcache.Application.DTO;

namespace Nutcache.Application.AutoMapper
{
    public class DtoToDomanMappingProfile : Profile
    {
        public DtoToDomanMappingProfile()
        {
            CreateMap<EmployeeDto, CreateEmployeeCommand>()
                .ConstructUsing(c => new CreateEmployeeCommand(
                    c.Name, 
                    c.BirthDate, 
                    c.Gender, 
                    c.Email, 
                    c.Cpf, 
                    c.StartDate, 
                    c.Team));

            CreateMap<EmployeeWithIdDto, UpdateEmployeeCommand>()
                .ConstructUsing(c => new UpdateEmployeeCommand(
                    c.Id,
                    c.Name,
                    c.BirthDate,
                    c.Gender,
                    c.Email,
                    c.Cpf,
                    c.StartDate,
                    c.Team));
        }
    }
}
