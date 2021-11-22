using System;

namespace MerchandiseService.Domain.Exceptions.EmployeeAggregate
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