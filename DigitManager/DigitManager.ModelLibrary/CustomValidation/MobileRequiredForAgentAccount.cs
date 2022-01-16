using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitManager.ModelLibrary.CustomValidation
{
    public class MobileRequiredForAgentAccount : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Agent agent = (Agent)validationContext.ObjectInstance;
            if (agent.IsByOwner)
                return ValidationResult.Success;

            string mobile = value == null ? null : value.ToString().Trim();
            var result = string.IsNullOrWhiteSpace(mobile) ? new ValidationResult("The Mobile field is required.",
                new[] { validationContext.MemberName })
                : null;
            return result;
        }
    }
}
