using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.MerchOrderAggregate
{
    public class MerchOrderStatus : Enumeration
    {
        public static MerchOrderStatus New = new(1, nameof(New));
        public static MerchOrderStatus GaveOut = new(1, nameof(GaveOut));
        public static MerchOrderStatus NotAvailable = new(1, nameof(NotAvailable));
        public static MerchOrderStatus Cancelled = new(1, nameof(Cancelled));
        public MerchOrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}