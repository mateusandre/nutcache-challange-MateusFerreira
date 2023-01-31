using AutoMapper;
using MediatR;
using Nutcache.Application.Commands;
using Nutcache.Application.DTO;
using Nutcache.Domain.Entities;
using Nutcache.Infra.Data.Repository;

namespace Nutcache.Application.Commands.Handlers
{
    public class EmployeeCommandHandler :
        IRequestHandler<CreateEmployeeCommand, EmployeeWithIdDto>,
        IRequestHandler<UpdateEmployeeCommand, EmployeeWithIdDto>,
        IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeCommandHandler(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeWithIdDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var employee = new Employee(
                request.Name,
                request.BirthDate,
                request.Gender,
                request.Email, request.Cpf,
                request.StartDate, request.Team);

            await _repository.CreateAsync(employee, cancellationToken).ConfigureAwait(false);

            return _mapper.Map<EmployeeWithIdDto>(employee);
        }

        public async Task<EmployeeWithIdDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var employee = new Employee(
                request.Id,
                request.Name,
                request.BirthDate,
                request.Gender,
                request.Email, request.Cpf,
                request.StartDate, request.Team);

            await _repository.UpdateAsync(employee, cancellationToken).ConfigureAwait(false);

            return _mapper.Map<EmployeeWithIdDto>(employee);
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _repository.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
