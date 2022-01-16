using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitManager.ModelLibrary
{
    public class OwnerRefreshToken
    {
        [Key]
        public int OwnerRefreshTokenId { get; set; }

        public int OwnerId { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
