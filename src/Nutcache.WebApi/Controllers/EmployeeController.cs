using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutcache.Application.Commands;
using Nutcache.Application.DTO;
using Nutcache.Application.Queries;

namespace Nutcache.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EmployeeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeWithIdDto>> GetAllEmployees()
        {
            return Ok(await _mediator.Send(new GetAllEmployeesQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeWithIdDto>> CreateEmployee([FromBody] EmployeeDto dto)
        {
            return Ok(await _mediator.Send(_mapper.Map <CreateEmployeeCommand>(dto)));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<EmployeeWithIdDto>> EditEmployee(Guid id, [FromBody] EmployeeDto dto)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdateEmployeeCommand>(new EmployeeWithIdDto(id, dto))));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteEmployeeCommand { Id = id }));
        }
    }
}
