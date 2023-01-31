using MediatR;
using Nutcache.Application.DTO;
using Nutcache.Application.Queries;

namespace Nutcache.WebUI.Data
{
    public class EmployeeService
    {
        private readonly IMediator _mediator;
        public EmployeeService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<EmployeeWithIdDto>> GetAllEmployeesAsync()
        {
            return await _mediator.Send(new GetAllEmployeesQuery());
        }
    }
}
