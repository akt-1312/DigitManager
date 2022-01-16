using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitManager.ModelLibrary.CustomValidation
{
    public class PasswordRequiredOnlyForAgent : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Agent agent = (Agent)validationContext.ObjectInstance;
            if (agent.IsByOwner)
                return ValidationResult.Success;

            string password = value == null ? null : value.ToString().Trim();
            var result = string.IsNullOrWhiteSpace(password) && agent.AgentId == 0 ? new ValidationResult("The Password field is required.",
                new[] { validationContext.MemberName })
                : null;
            return result;
        }
    }
}
