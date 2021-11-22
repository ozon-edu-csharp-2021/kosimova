using System;

namespace MerchandiseService.Domain.Exceptions.MerchPackAggregate
{
    public class ItemTypeException : Exception
    {
        public ItemTypeException(string message) : base(message)
        {
            
        }
        
        public ItemTypeException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}