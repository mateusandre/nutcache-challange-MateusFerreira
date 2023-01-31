using FluentValidation.TestHelper;
using Nutcache.Application.DTO;
using Nutcache.Application.Validations;
using Nutcache.Domain.Enums;

namespace Nutcache.Application.UnitTests.Validations
{
    public class EmployeeDtoValidationTests
    {

        private readonly EmployeeDtoValidation _validator = new EmployeeDtoValidation();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_have_error_when_Name_is_null_or_empty(string name)
        {
            var model = new EmployeeDto
            {
                Name = name
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("test")]
        [InlineData("test@")]
        public void Should_have_error_when_Email_is_invalid(string email)
        {
            var model = new EmployeeDto
            {
                Email = email
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123")]
        [InlineData("12345678912")]
        [InlineData("123.456.789-12")]
        public void Should_have_error_when_Cpf_is_invalid(string cpf)
        {
            var model = new EmployeeDto
            {
                Cpf = cpf
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Cpf);
        }

        [Theory]
        [InlineData("81444257587")]
        [InlineData("814.442.575-87")]
        [InlineData("15810703577")]
        [InlineData("158.107.035-77")]
        public void Should_not_have_error_when_Cpf_is_valid(string cpf)
        {
            var model = new EmployeeDto
            {
                Cpf = cpf
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Cpf);
        }

        [Fact]
        public void Should_not_have_error_when_Team_is_null()
        {
            var model = new EmployeeDto
            {
                Team = null
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Team);
        }

        [Fact]
        public void Should_have_error_when_Team_is_not_present_on_enum()
        {
            var enumvalues = Enum.GetValues(typeof(Team));
            var model = new EmployeeDto
            {
                Team = (Team)enumvalues.Length
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Team);
        }
    }
}
