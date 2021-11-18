using MerchandiseService.Domain.AggregateModels.Exceptions.EmployeeAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        public Employee(EmployeeName fullname, Email eMail)
        {
            Email = eMail;
            FullName = fullname;
            Dismissed = false;
        }
        /// <summary>
        /// Почта работника
        /// </summary>
        public  Email Email { get; }
        /// <summary>
        /// Фамилия и имя работника
        /// </summary>
        public EmployeeName FullName { get; }
        
        /// <summary>
        /// Статус об увольнении
        /// </summary>
        public bool Dismissed { get; private set;}
        
        
        /// <summary>
        /// Изменение статуса об увольнении сотрудника
        /// </summary>
        /// 
        public void SetDismissed()
        {
            if (this.Dismissed)
                throw new DismissedEventException($"Employee was already dissmised");
            
            this.Dismissed = true;
        }
        
    }
}