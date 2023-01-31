using MediatR;
using Nutcache.Application.DTO;
using Nutcache.Domain.Enums;

namespace Nutcache.Application.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeWithIdDto>
    {
        public CreateEmployeeCommand(
            string name,
            DateTime birthDate, 
            Gender gender,
            string email,
            string cpf,
            DateTime startDate,
            Team? team)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            Cpf = cpf;
            StartDate = startDate;
            Team = team;
        }

        public string Name { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public Gender Gender { get; protected set; }
        public string Email { get; protected set; }
        public string Cpf { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public Team? Team { get; protected set; }
    }
}
