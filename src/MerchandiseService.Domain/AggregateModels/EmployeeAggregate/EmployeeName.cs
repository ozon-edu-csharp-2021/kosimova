namespace MerchandiseService.Domain.AggregateModels.EmployeeAggregate
{
    public class EmployeeName
    {
        public Name FirstName { get; }
        public Name SecondName { get; }

        public EmployeeName(string firstName, string secondName)
        {
            FirstName = new Name(firstName);
            SecondName = new Name(secondName);
        }
    }
}