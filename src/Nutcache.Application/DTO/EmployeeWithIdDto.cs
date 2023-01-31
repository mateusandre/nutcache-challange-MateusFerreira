using Nutcache.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Nutcache.Application.DTO
{
    public class EmployeeWithIdDto : EmployeeDto
    {
        public EmployeeWithIdDto(){}
        public EmployeeWithIdDto(Guid id, EmployeeDto dto)
        {
            Id = id;
            Name= dto.Name;
            BirthDate = dto.BirthDate;
            Gender = dto.Gender;
            Email = dto.Email;
            Cpf = dto.Cpf;
            StartDate = dto.StartDate;
            Team = dto.Team;
        }

        [Key]
        public Guid Id { get; set; }
    }
}
