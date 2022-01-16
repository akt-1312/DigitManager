using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitManager.ModelLibrary.CustomValidation
{
    public class AgentRequiredCommissionMultiply : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string valueAsString = value == null ? "" : value.ToString().Trim();

            Agent agent = (Agent)validationContext.ObjectInstance;
            if (agent.AgentOrPlayer == AgentOrPlayerEnum.Agent)
            {
                if (string.IsNullOrWhiteSpace(valueAsString))
                    return new ValidationResult("Commission Rate field is required.",
                new[] { validationContext.MemberName });

                if (!float.TryParse(valueAsString, out float comRate))
                {
                    return new ValidationResult("Commission Rate field is not valid.",
                new[] { validationContext.MemberName });
                }
                else
                {
                    if (comRate < 8f || (comRate > 20f))
                        return new ValidationResult("Commission Rate must be between 8 and 20.",
                new[] { validationContext.MemberName });
                }

                return null;
            }
            else if(agent.AgentOrPlayer == AgentOrPlayerEnum.Player)
            {
                if(!string.IsNullOrWhiteSpace(valueAsString) && float.Parse(valueAsString) != 0f)
                    return new ValidationResult("Playre role must be zero commission rate.",
                new[] { validationContext.MemberName });

                return null;
            }
            else
            {
                return new ValidationResult("Your choosen role is not valid.",
                new[] { validationContext.MemberName });
            }
        }
    }
}
