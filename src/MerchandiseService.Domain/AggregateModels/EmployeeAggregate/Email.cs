using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MerchandiseService.Domain.AggregateModels.Exceptions.EmployeeAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.EmployeeAggregate
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string emailString)
            => Value = emailString;

        public static Email Create(string emailString)
        {
            if (IsValidEmail(emailString))
            {
                return new Email(emailString);
            }
            
            throw new EmailInvalidException($"Wrong Email: {emailString}");
        }
        
        public override string ToString()
            => Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private static bool IsValidEmail(string emailString)
            => Regex.IsMatch(emailString, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }
}