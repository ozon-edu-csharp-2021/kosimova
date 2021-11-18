using System;

namespace MerchandiseService.Domain.AggregateModels.MerchOrderAggregate
{
    public class CreatedDate
    {
        public CreatedDate(DateTime? date)
        {
            Value = date;
        }
        public DateTime? Value { get; }
    }
}