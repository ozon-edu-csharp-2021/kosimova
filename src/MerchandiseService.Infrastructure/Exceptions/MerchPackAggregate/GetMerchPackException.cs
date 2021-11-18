using System;

namespace MerchandiseService.Infrastructure.Exceptions.MerchPackAggregate
{
    public class GetMerchPackException : Exception
    {
        public GetMerchPackException(string message) : base(message)
        {
            
        }
        
        public GetMerchPackException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}