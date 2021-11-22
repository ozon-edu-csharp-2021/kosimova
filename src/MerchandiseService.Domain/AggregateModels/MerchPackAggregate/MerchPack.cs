using System;
using System.Collections.Generic;
using System.Linq;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;
using MerchandiseService.Domain.Exceptions.MerchPackAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.MerchPackAggregate
{
    public class MerchPack : Entity
    {
        public MerchPack(MerchType type, List<ItemType> items)
        {
            MerchType = type;
            ItemTypes = items ?? new List<ItemType>();
        }
        
        public MerchType MerchType { get; }
        public List<ItemType> ItemTypes { get; private set;}

        /// <summary>
        /// Добалвение листа товаров в мерч пакет
        /// </summary>
        ///
        public void AddRangeOfItemTypes(List<ItemType> newTypes)
        {
            if (newTypes == null || !newTypes.Any())
                throw new ItemTypeException("There is no itemType to add");
            foreach (var item in newTypes)
            {
                if (ItemTypes.Any(x => x.Id == item.Id)) continue;
                AddItemType(item);
            }
        }
        
        /// <summary>
        /// Добалвение одного товара в мерч пакет
        /// </summary>
        ///
        public void AddItemType(ItemType newType)
        {
            if (ItemTypes.Any(x => x.Id == newType.Id))
                throw new ItemTypeException($"MerchPack {newType.Name} already has such itemType");
            ItemTypes.Add(newType);
        }
    
        /// <summary>
        /// Удаление товара из мерч пакета
        /// </summary>
        ///
        public void RemoveItemType(ItemType oldType)
        {
            if (ItemTypes == null || !ItemTypes.Any())
                throw new ItemTypeException("MerchPack doesn't have any itemType");
            if (ItemTypes.All(x => x.Id != oldType.Id))
                throw new ItemTypeException("MerchPack doesn't have such itemType");
            ItemTypes.Remove(oldType);
        }
    }
}