using MediatR;

namespace Nutcache.Application.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
