using System;

namespace MerchandiseService.Domain.AggregateModels.MerchOrderAggregate
{
    public class GaveOutDate
    {
        public GaveOutDate(DateTime? date)
        {
            Value = date;
        }
        public DateTime? Value { get; }
    }
}