using System;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.MerchItemAggreagate
{
    public class MerchStatus : Enumeration
    {
        public static MerchStatus New = new(1, nameof(New));
        public static MerchStatus Ready = new(1, nameof(Ready));
        public static MerchStatus NotAvailable = new(1, nameof(NotAvailable));
        public static MerchStatus Cancelled = new(1, nameof(Cancelled));
        public MerchStatus(int id, string name) : base(id, name)
        {
        }
    }
}