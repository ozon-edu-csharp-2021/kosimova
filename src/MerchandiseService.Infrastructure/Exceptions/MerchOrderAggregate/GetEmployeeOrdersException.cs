using System;

namespace MerchandiseService.Infrastructure.Exceptions.MerchOrderAggregate
{
    public class GetEmployeeOrdersException : Exception
    {
        public GetEmployeeOrdersException(string message) : base(message)
        {
            
        }
        
        public GetEmployeeOrdersException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}