using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.EmployeeMerchAggregate
{
    public class Employee : Entity
    {
        public Employee(int employeeId, FirstName firstName, SecondName secondName, Email eMail)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            SecondName = secondName;
            EMail = eMail;
        }

        public int EmployeeId { get; }
        public FirstName FirstName { get; }
        public SecondName SecondName { get; }
        public Email EMail { get; }
    }
}