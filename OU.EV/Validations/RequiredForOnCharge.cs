using OU.EV.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OU.EV.Validations
{
    public class RequiredForOnChargeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var timeSpan = (TimeSpan)value;
            var slot = validationContext.ObjectInstance as Slot;

            if (timeSpan != null)
            {
                if (slot.Status == Status.OnCharge && (timeSpan < new TimeSpan(0, 15, 0) || timeSpan > new TimeSpan(4, 00, 0)))
                {
                    return new ValidationResult("Duration must be between 00:15:00 and 04:00:00 for a status of On Charge.");
                }
            }

            return ValidationResult.Success;
        }
    }
}