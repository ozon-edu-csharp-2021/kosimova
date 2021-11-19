using System.Collections.Generic;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;
using MerchandiseService.Domain.AggregateModels.MerchPackAggregate;
using MerchandiseService.Domain.Exceptions.MerchPackAggregate;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class MerchPackAggregateTests
    {
        public MerchPackAggregateTests()
        {}

        [Fact]
        public void AddRangeOfItemTypesSuccess()
        {
            //Arrange
            var merchPack = new MerchPack(
                MerchType.WelcomePack,
                new List<ItemType>());

            var newTypes = new List<ItemType>()
            {
                ItemType.Notepad,
                ItemType.Pen,
                ItemType.Socks, 
                ItemType.Bag
            };
            //Act
            merchPack.AddRangeOfItemTypes(newTypes);
            //Assert
            Assert.Equal(merchPack.ItemTypes, newTypes);
        }
        
        [Fact]
        public void AddRangeOfItemTypesFail()
        {
            //Arrange
            var merchPack = new MerchPack(
                MerchType.WelcomePack,
                new List<ItemType>());
            
            //Assert
            Assert.Throws<ItemTypeException>(() => merchPack.AddRangeOfItemTypes(null));
        }
        
        [Fact]
        public void AddItemTypeSuccess()
        {
            //Arrange
            var merchPack = new MerchPack(
                MerchType.WelcomePack,
                new List<ItemType>());

            var newType = ItemType.Bag;
            //Act
            merchPack.AddItemType(newType);
            //Assert
            Assert.Contains((newType), merchPack.ItemTypes);

        }
        
        [Fact]
        public void AddItemTypeFail()
        {
            //Arrange
            var merchPack = new MerchPack(
                MerchType.WelcomePack,
                new List<ItemType>(){ItemType.Bag});
            
            var newType = ItemType.Bag;
            
            //Assert
            Assert.Throws<ItemTypeException>(() => merchPack.AddItemType(newType));
        }
        
        
        [Fact]
        public void RemoveItemTypeSuccess()
        {
            //Arrange
            var merchPack = new MerchPack(
                MerchType.WelcomePack,
                new List<ItemType>()
                    {
                        ItemType.Bag,
                        ItemType.Notepad
                    });
            var removeType = ItemType.Bag;
            //Act
            merchPack.RemoveItemType(removeType);
            //Assert
            Assert.DoesNotContain((removeType), merchPack.ItemTypes);
        }
        
        [Fact]
        public void RemoveItemTypeFail()
        {
            //Arrange
            var merchPack = new MerchPack(
                MerchType.WelcomePack,
            new List<ItemType>()
                    {
                        ItemType.Bag,
                        ItemType.Notepad
                    });
            var removeType = ItemType.Socks;
           
            //Assert
            Assert.Throws<ItemTypeException>(() => merchPack.RemoveItemType(removeType));
        }
    }
}