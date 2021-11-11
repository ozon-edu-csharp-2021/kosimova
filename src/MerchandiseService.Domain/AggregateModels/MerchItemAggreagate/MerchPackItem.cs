using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.MerchItemAggreagate
{
    public class MerchPackItem : Entity
    {
        public MerchPackItem(MerchType merchType, List<ItemType> items)
        {
            MerchType = merchType;
            Items = items;
        }

        public MerchType MerchType { get; }
        public List<ItemType> Items { get; }
    }
}