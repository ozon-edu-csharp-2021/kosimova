using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.MerchOrderAggregate
{
    public class MerchOrderPriority : Enumeration
    {
        public static MerchOrderPriority ManualRequest = new(1, nameof(ManualRequest));
        public static MerchOrderPriority AutomaticIssue = new(1, nameof(AutomaticIssue));
        public MerchOrderPriority(int id, string name) : base(id, name)
        {
        }
    }
}