using System;

namespace MerchandiseService.Domain.Exceptions.MerchOrderAggregate
{
    public class DateExceptions : Exception
    {
        public DateExceptions(string message) : base(message)
        {
            
        }
        
        public DateExceptions(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}