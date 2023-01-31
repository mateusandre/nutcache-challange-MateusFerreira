using Bogus;
using Bogus.Extensions.Brazil;
using Nutcache.Application.DTO;
using Nutcache.Domain.Enums;

namespace Nutcache.WebApi.IntegrationTests.Faker
{
    public static class EmployeeDtoFaker
    {
        public static EmployeeDto Generate()
        {
            return new Faker<EmployeeDto>()
                .RuleFor(x => x.Name, f => f.Person.FirstName)
                .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
                .RuleFor(x => x.StartDate, DateTime.Now)
                .RuleFor(x => x.Cpf, f => f.Person.Cpf())
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Gender, Gender.Male)
                .RuleFor(x => x.Team, Team.Backend)
                .Generate();
        }

        public static EmployeeDto GenerateWithNullRequiredFields()
        {
            return new Faker<EmployeeDto>().Generate();
        }

        public static EmployeeDto GenerateWithInvalidCpf()
        {
            var employee = Generate();
            employee.Cpf = "123.456.789-12";

            return employee;
        }        
    }
}
