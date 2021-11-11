using MediatR;

namespace MerchandiseService.Infrastructure.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest
    {
        public int EmployeeId { get; init; }
        public string FirstName { get; init; }
        public string SecondName { get; init; }
        public string EMail { get; init; }
    }
}