using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitManager.ModelLibrary
{
    public class AgentRefreshToken
    {
        [Key]
        public int AgentRefreshTokenId { get; set; }

        public int AgentId { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

        public virtual Agent Agent { get; set; }
    }
}
