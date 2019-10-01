using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesRental.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            //If membership type is "Unknow" or "Pay As You Go" we are not checking age
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            //If membership type other than "Pay As You Go" is selected, we need to have birthday info
            if (customer.Birthday == null)
                return new ValidationResult("Birthday is required");

            //Calculation of age (not fully accurate, only year is considered)
            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            //Validation logic based on age
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old.");

        }
    }
}