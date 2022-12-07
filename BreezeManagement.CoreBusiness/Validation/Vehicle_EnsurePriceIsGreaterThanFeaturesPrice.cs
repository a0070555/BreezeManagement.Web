using BreezeManagement.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.CoreBusiness.Validation
{
    internal class Vehicle_EnsurePriceIsGreaterThanFeaturesPrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var vehicle = validationContext.ObjectInstance as Vehicle;
            if (vehicle != null)
            {
                if (!vehicle.ValidatePricing())
                {
                    return new ValidationResult($"The vehicle's price is less than the summary of its features: {vehicle.TotalFeatureCost} !",
                        new[] { validationContext.MemberName });
                }
            }

            return ValidationResult.Success;
        }
    }
}
