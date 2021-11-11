using System;

namespace MerchandiseService.Domain.Exceptions
{
    public class MerchStatusException : Exception
    {
        public MerchStatusException(string message) : base(message)
        {
            
        }
        
        public MerchStatusException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}