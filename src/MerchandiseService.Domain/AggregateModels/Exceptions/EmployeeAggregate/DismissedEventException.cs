using System;

namespace MerchandiseService.Domain.AggregateModels.Exceptions.EmployeeAggregate
{
    public class DismissedEventException : Exception
    {
        public DismissedEventException(string message) : base(message)
        {
            
        }
        
        public DismissedEventException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}