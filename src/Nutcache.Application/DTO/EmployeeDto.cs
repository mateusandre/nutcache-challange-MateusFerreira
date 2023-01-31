using Nutcache.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Nutcache.Application.DTO
{
    public class EmployeeDto
    {        
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public Team? Team { get; set; }
    }
}
