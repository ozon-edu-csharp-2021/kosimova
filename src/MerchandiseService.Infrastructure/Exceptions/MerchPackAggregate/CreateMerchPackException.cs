using System;

namespace MerchandiseService.Infrastructure.Exceptions.MerchPackAggregate
{
    public class CreateMerchPackException : Exception
    {
        public CreateMerchPackException(string message) : base(message)
        {
            
        }
        
        public CreateMerchPackException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}