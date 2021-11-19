using System;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;
using MerchandiseService.Domain.Exceptions.MerchOrderAggregate;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class MerchOrderAggregateTests
    {
        public MerchOrderAggregateTests()
        {}


        [Fact]
        public void ChangeStatusSuccess()
        {
            //Arrange
            var merchOrder = new MerchOrder(
                new EmployeeId(1),
                ClothingSize.S,
                MerchType.WelcomePack,
                MerchOrderPriority.AutomaticIssue,
                MerchOrderStatus.New);
            //Act
            merchOrder.ChangeStatus(MerchOrderStatus.NotAvailable);
            //Assert
            Assert.Equal(merchOrder.Status, MerchOrderStatus.NotAvailable);
        }
        
        [Fact]
        public void ChangeStatusFromCancelledFail()
        {
            //Arrange
            var merchOrder = new MerchOrder(
                new EmployeeId(1),
                ClothingSize.S,
                MerchType.WelcomePack,
                MerchOrderPriority.AutomaticIssue,
                MerchOrderStatus.Cancelled);
            
            //Assert
            Assert.Throws<MerchOrderStatusException>(() => merchOrder.ChangeStatus(MerchOrderStatus.GaveOut));
        }
        
        [Fact]
        public void ChangeStatusFromGaveOutFail()
        {
            //Arrange
            var merchOrder = new MerchOrder(
                new EmployeeId(1),
                ClothingSize.S,
                MerchType.WelcomePack,
                MerchOrderPriority.AutomaticIssue,
                MerchOrderStatus.GaveOut);
            
            //Assert
            Assert.Throws<MerchOrderStatusException>(() => merchOrder.ChangeStatus(MerchOrderStatus.New));
        }
        
       [Fact]
        public void SetGaveoutDateSuccess()
        {
            //Arrange
            var merchOrder = new MerchOrder(
                new EmployeeId(1),
                ClothingSize.S,
                MerchType.WelcomePack,
                MerchOrderPriority.AutomaticIssue,
                MerchOrderStatus.New);
        
            var gaveoutDate = DateTime.Now.AddDays(3);
            //Act
            merchOrder.SetGaveoutDate(gaveoutDate);
            //Asserts
            Assert.Equal(gaveoutDate, merchOrder.GaveOutDate.Value);
        }
        
        [Fact]
        public void SetGaveoutDateFail()
        {
            //Arrange
            var merchOrder = new MerchOrder(
                new EmployeeId(1),
                ClothingSize.S,
                MerchType.WelcomePack,
                MerchOrderPriority.AutomaticIssue,
                MerchOrderStatus.New);
        
            var gaveOutDate = DateTime.Now.Subtract(new TimeSpan(1, 1, 1));
            
            //Assert
            Assert.Throws<DateExceptions>(() => merchOrder.SetGaveoutDate(gaveOutDate));
        }
        
        [Fact]
        public void SetGaveoutDateNotNullFail()
        {
            //Arrange
            var merchOrder = new MerchOrder(
                new EmployeeId(1),
                ClothingSize.S,
                MerchType.WelcomePack,
                MerchOrderPriority.AutomaticIssue,
                MerchOrderStatus.New);
        
            var gaveoutDate = DateTime.Now.AddDays(3);
            merchOrder.SetGaveoutDate(gaveoutDate);
            
            //Assert
            Assert.Throws<DateExceptions>(() => merchOrder.SetGaveoutDate(gaveoutDate));
        
        }
    }
}