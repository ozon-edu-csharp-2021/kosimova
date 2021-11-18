using System;

namespace MerchandiseService.Domain.Exceptions.EmployeeAggregate
{
    public class EmailInvalidException : Exception
    {
        public EmailInvalidException(string message) : base(message)
        {
            
        }
        
        public EmailInvalidException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}