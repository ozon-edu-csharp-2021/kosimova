namespace MerchandiseService.Domain.AggregateModels.MerchOrderAggregate
{
    public class EmployeeId
    {
        public EmployeeId(long value)
        {
            Value = value;
        }

        public long Value { get; }
    }
}