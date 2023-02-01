using AutoMapper;
using MediatR;
using Nutcache.Application.Commands;
using Nutcache.Application.DTO;
using Nutcache.Application.Queries;

namespace Nutcache.WebUI.Data
{
    public class EmployeeService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EmployeeService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeWithIdDto>> GetAllEmployeesAsync()
        {
            return await _mediator.Send(new GetAllEmployeesQuery());
        }

        public async Task SaveAsync(EmployeeDto employee, Guid? id)
        {
            if (id != null && id != Guid.Empty)
                await _mediator.Send(_mapper.Map<UpdateEmployeeCommand>(new EmployeeWithIdDto((Guid)id, employee)));
            else
                await _mediator.Send(_mapper.Map<CreateEmployeeCommand>(employee));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteEmployeeCommand { Id = id });
        }
    }
}
