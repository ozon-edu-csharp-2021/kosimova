using System;

namespace MerchandiseService.Domain.AggregateModels.Exceptions.MerchOrderAggregate
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