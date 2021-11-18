using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Infrastructure.Exceptions.MerchOrderAggregate;
using MerchandiseService.Infrastructure.Queries.MerchOrderAggregate;

namespace MerchandiseService.Infrastructure.Handlers.MerchOrderAggregate
{
    public class GetEmployeeOrdersQueryHandler : IRequestHandler<GetEmployeeOrdersQuery, List<MerchOrder>>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;
        private readonly IEmployeeRepository _employeeRepository;
        
        public GetEmployeeOrdersQueryHandler(IMerchOrderRepository stockItemRepository, IEmployeeRepository employeeRepository)
        {
            _merchOrderRepository = stockItemRepository;
            _employeeRepository = employeeRepository;
        }
        
        public async Task<List<MerchOrder>> Handle(GetEmployeeOrdersQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (employee == null)
            {
                //check if there is any employee with such email in EmployeeService:
                bool existEmployee = false;
                if (!existEmployee)
                    throw new GetEmployeeOrdersException($"There is no employee with Email {request.Email}");
            }
            
            var result = await _merchOrderRepository.GetByEmployeeIdAsync(employee.Id, cancellationToken);
            return result;
        }
    }
}