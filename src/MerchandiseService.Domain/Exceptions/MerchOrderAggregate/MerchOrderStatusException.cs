using System;

namespace MerchandiseService.Domain.Exceptions.MerchOrderAggregate
{
    public class MerchOrderStatusException : Exception
    {
        public MerchOrderStatusException(string message) : base(message)
        {
            
        }
        
        public MerchOrderStatusException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}