using System;

namespace MerchandiseService.Infrastructure.Exceptions.MerchOrderAggregate
{
    public class CreateMerchOrderException : Exception
    {
        public CreateMerchOrderException(string message) : base(message)
        {
            
        }
        
        public CreateMerchOrderException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}