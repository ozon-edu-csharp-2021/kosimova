using MerchandiseService.Domain.AggregateModels.EmployeeAggregate;
using MerchandiseService.Domain.Exceptions.EmployeeAggregate;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class EmployeeAggregateTests
    {
        public EmployeeAggregateTests()
        {}
        
        
        [Fact]
        public void CreateEmailSuccess()
        {
            //Arrange
            var email = "test@ozon.com";

            var newEmail = Email.Create(email);
           //Assert
            Assert.NotNull(newEmail);
        }

        
        [Fact]
        public void CreateEmailFail()
        {
            //Arrange
            var email = "tesozoncom";
            
           
            //Assert
            Assert.Throws<EmailInvalidException>(() => Email.Create(email));
        }



        [Fact]
        public void SetDismissedSuccess()
        {
            //Arrange
            var employee = new Employee(
                new EmployeeName("Test", "Test"),
                new Email("test@ozon.com"));
            
            //Act
            employee.SetDismissed();
            
            //Assert
            Assert.True(employee.Dismissed);
        }
        
        [Fact]
        public void SetDismissedFail()
        {
            //Arrange
            var employee = new Employee(
                new EmployeeName("Test", "Test"),
                new Email("test@ozon.com"));
            employee.SetDismissed();
            
            //Assert
            Assert.Throws<DismissedEventException>(() => employee.SetDismissed());
        }

    }
}