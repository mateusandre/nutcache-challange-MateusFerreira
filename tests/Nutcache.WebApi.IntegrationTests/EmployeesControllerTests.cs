using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Nutcache.Application.DTO;
using Nutcache.Application.Middlewares.Responses;
using Nutcache.WebApi.IntegrationTests.Faker;
using System.Net;
using System.Text;

namespace Nutcache.WebApi.IntegrationTests
{
    public class EmployeesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public EmployeesControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_all_employees_endpoint_should_return_success()
        {
            // Act
            var response = await _client.GetAsync("api/employees");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EmployeeWithIdDto>>(responseString);

            Assert.Equal(typeof(List<EmployeeWithIdDto>), result.GetType());
        }

        [Fact]
        public async Task Should_return_404_when_trying_to_update_non_existing_data()
        {
            // Arrange
            var requestContent = GenerateRequestContent();

            // Act
            var response = await _client.PutAsync($"api/employees/{Guid.NewGuid()}", requestContent);

            // Assert
            await AssertNotFoundResultAsync(response);
        }

        [Fact]
        public async Task Should_return_404_when_trying_to_delete_non_existing_data()
        {
            // Act
            var response = await _client.DeleteAsync($"api/employees/{Guid.NewGuid()}");

            // Assert
            await AssertNotFoundResultAsync(response);
        }

        [Fact]
        public async Task Should_create_a_new_employee()
        {
            // Arrange
            var requestContent = GenerateRequestContent();

            // Act
            var response = await _client.PostAsync("api/employees", requestContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Should_create_a_new_employee_without_team()
        {
            // Arrange
            var employee = EmployeeDtoFaker.Generate();
            employee.Team = null;
            var requestContent = GenerateRequestContent(employee);

            // Act
            var response = await _client.PostAsync("api/employees", requestContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [MemberData(nameof(InvalidEmployeeData))]
        public async Task Should_not_create_an_employee_with_invalid_data(EmployeeDto employee)
        {
            // Arrange
            var requestContent = GenerateRequestContent(employee);

            // Act
            var response = await _client.PostAsync("api/employees", requestContent);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }        

        [Fact]
        public async Task Should_update_an_employee()
        {
            // Arrange
            var requestContent = GenerateRequestContent();
            var response = await _client.PostAsync("api/employees", requestContent);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EmployeeWithIdDto>(responseString);
            var updatedData = EmployeeDtoFaker.Generate();
            requestContent = GenerateRequestContent(updatedData);
            response = await _client.PutAsync($"api/employees/{result.Id}", requestContent);

            // Assert
            response.EnsureSuccessStatusCode();

            responseString = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<EmployeeWithIdDto>(responseString);
            Assert.Equal(updatedData.Name, result.Name);
            Assert.Equal(updatedData.Cpf, result.Cpf);
            Assert.Equal(updatedData.BirthDate, result.BirthDate);
            Assert.Equal(updatedData.StartDate, result.StartDate);
            Assert.Equal(updatedData.Email, result.Email);
            Assert.Equal(updatedData.Gender, result.Gender);
            Assert.Equal(updatedData.Team, result.Team);
        }

        [Theory]
        [MemberData(nameof(InvalidEmployeeData))]
        public async Task Should_not_update_an_employee_with_invalid_data(EmployeeDto employee)
        {
            // Arrange
            var requestContent = GenerateRequestContent(employee);

            // Act
            var response = await _client.PutAsync($"api/employees/{Guid.NewGuid()}", requestContent);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        public static IEnumerable<object[]> InvalidEmployeeData()
        {
            yield return new object[]
            {
                EmployeeDtoFaker.GenerateWithNullRequiredFields(),
            };

            yield return new object[]
            {
                EmployeeDtoFaker.GenerateWithInvalidCpf()
            };
        }

        private async Task AssertNotFoundResultAsync(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ErrorResponse>(responseString);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal(expected: typeof(ErrorResponse), actual: result.GetType());
        }

        private StringContent GenerateRequestContent(EmployeeDto? dto = null)
        {
            var employee = dto ?? EmployeeDtoFaker.Generate();
            var serializedData = JsonConvert.SerializeObject(employee);
            return new StringContent(serializedData, Encoding.UTF8, "application/json");
        }
    }
}
