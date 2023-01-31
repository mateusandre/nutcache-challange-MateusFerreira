using Nutcache.Domain.Enums;

namespace Nutcache.Application.DTO
{
    public class EmployeeDto
    {        
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime StartDate { get; set; }
        public Team? Team { get; set; }
    }
}
