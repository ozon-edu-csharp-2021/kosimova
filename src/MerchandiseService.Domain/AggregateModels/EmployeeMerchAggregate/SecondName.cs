using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.EmployeeMerchAggregate
{
    public class SecondName : ValueObject
    {
    public string Value { get; }
        
    public SecondName(string name)
    {
        Value = name;
    }
        
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    }
}