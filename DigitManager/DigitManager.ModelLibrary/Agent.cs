using DigitManager.ModelLibrary.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitManager.ModelLibrary
{
    public class Agent
    {
        public Agent()
        {
            AgentRefreshTokens = new HashSet<AgentRefreshToken>();
        }
        private float? _agentCommissionMultiply;

        [Key]
        public int AgentId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [RegularExpression(@"^([A-Za-z0-9]{4,30})*$", ErrorMessage = "Not allow whitespace and special characters. Must be between 4 and 30 characters.")]
        public string UserName { get; set; }

        [PasswordRequiredOnlyForAgent]
        [DataType(DataType.Password)]
        [RegularExpression(@"^([A-Za-z0-9\S]{5,15})*$", ErrorMessage = "Not allow whitespace. Must be between 5 and 15 characters.")]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{9,12})$", ErrorMessage = "Not a valid phone number")]
        [MobileRequiredForAgentAccount]
        public string Mobile { get; set; }

        public string AgentGuid { get; set; }

        [Display(Name = "Commission Rate")]
        //[Required]
        //[Range(8,20, ErrorMessage = "Commission Rate must be between 8 and 20.")]
        [AgentRequiredCommissionMultiply]
        [RegularExpression(@"^([0-9]{1,1})([0-9]{1,1})?(\.5)?$")]
        public float? AgentCommissionMultiply
        {
            get { return _agentCommissionMultiply; }
            set { _agentCommissionMultiply = value ?? 0f; }
        }

        public bool IsActive { get; set; }

        [Required]
        public AgentOrPlayerEnum AgentOrPlayer { get; set; }

        public bool IsByOwner { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<AgentRefreshToken> AgentRefreshTokens { get; set; }
    }
}
