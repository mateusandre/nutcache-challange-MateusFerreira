using MediatR;
using Nutcache.Application.DTO;
using Nutcache.Domain.Entities;

namespace Nutcache.Application.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeWithIdDto>>
    {
    }
}
