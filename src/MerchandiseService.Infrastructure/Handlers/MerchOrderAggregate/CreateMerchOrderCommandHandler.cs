using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregateModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Commands.CreateMerchOrder;
using MerchandiseService.Infrastructure.Exceptions.MerchOrderAggregate;

namespace MerchandiseService.Infrastructure.Handlers.MerchOrderAggregate
{
    public class CreateMerchOrderCommandHandler : IRequestHandler<CreateMerchOrderCommand, MerchOrder>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public CreateMerchOrderCommandHandler(IMerchOrderRepository stockItemRepository, IEmployeeRepository employeeRepository)
        {
            _merchOrderRepository = stockItemRepository;
            _employeeRepository = employeeRepository;
        }
        
        public async Task<MerchOrder> Handle(CreateMerchOrderCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (employee == null)
            {
                // get employee Fullname from Employee-Service
                employee = new Employee(
                    new EmployeeName("firstName", "secondName"),
                    new Email(request.Email)
                    );
                await _employeeRepository.CreateAsync(employee, cancellationToken);
            }

            var previousOrders = await _merchOrderRepository.GetByEmployeeIdAsync(employee.Id, cancellationToken);
            if (previousOrders is not null && previousOrders.Any(x => x.MerchType.Id == request.MerchType && Equals(x.Status, MerchOrderStatus.GaveOut)))
                throw new CreateMerchOrderException("This employee was already gave out this merch pack");

            //create order:
            var newOrder = new MerchOrder(
                new EmployeeId(employee.Id),
                Enumeration.GetAll<ClothingSize>().FirstOrDefault(it => it.Id.Equals(request.ClothingSize)), 
           Enumeration.GetAll<MerchType>().FirstOrDefault(it => it.Id.Equals(request.MerchType)), 
                    MerchOrderPriority.ManualRequest,
                    MerchOrderStatus.New
                );
            // check merchpack in Stock-Api to set orderStatus: if it's not available and it is manual request, Cancell this, else set Not Available status:
            newOrder.ChangeStatus(MerchOrderStatus.NotAvailable);
            
            await _merchOrderRepository.CreateAsync(newOrder, cancellationToken);
            return newOrder;
        }
    }
}