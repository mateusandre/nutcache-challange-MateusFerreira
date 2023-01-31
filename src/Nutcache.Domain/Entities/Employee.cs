using Nutcache.Domain.Enums;

namespace Nutcache.Domain.Entities
{
    public class Employee : Entity
    {
        public Employee() : base() { }
        public Employee(Guid id, string name, DateTime birthDate, Gender gender, string email, string cpf, DateTime startDate, Team? team)
            : base(id)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            Cpf = cpf;
            StartDate = startDate;
            Team = team;
        }

        public Employee(string name, DateTime birthDate, Gender gender, string email, string cpf, DateTime startDate, Team? team)
            : base()
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            Cpf = cpf;
            StartDate = startDate;
            Team = team;
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public DateTime StartDate { get; private set; }
        public Team? Team { get; private set; }
    }
}
