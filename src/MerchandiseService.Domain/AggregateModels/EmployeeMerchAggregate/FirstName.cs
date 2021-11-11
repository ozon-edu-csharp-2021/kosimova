using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.EmployeeMerchAggregate
{
    public class FirstName: ValueObject
    {
        public string Value { get; }
        
        public FirstName(string name)
        {
            Value = name;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}