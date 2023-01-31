using AutoMapper;
using MediatR;
using Nutcache.Application.DTO;
using Nutcache.Domain.Entities;
using Nutcache.Infra.Data.Repository;

namespace Nutcache.Application.Queries.Handlers
{
    public class EmployeeQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeWithIdDto>>
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeQueryHandler(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeWithIdDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetAllAsync(cancellationToken).ConfigureAwait(false);

            return _mapper.Map<IEnumerable<EmployeeWithIdDto>>(employees);
        }
    }
}
