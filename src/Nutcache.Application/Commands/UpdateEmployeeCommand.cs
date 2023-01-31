using MediatR;
using Nutcache.Application.DTO;
using Nutcache.Domain.Entities;
using Nutcache.Domain.Enums;

namespace Nutcache.Application.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeWithIdDto>
    {
        public UpdateEmployeeCommand(
            Guid id,
            string name,
            DateTime birthDate,
            Gender gender,
            string email,
            string cpf,
            DateTime startDate,
            Team? team)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            Cpf = cpf;
            StartDate = startDate;
            Team = team;
        }

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public Gender Gender { get; protected set; }
        public string Email { get; protected set; }
        public string Cpf { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public Team? Team { get; protected set; }
    }
}
