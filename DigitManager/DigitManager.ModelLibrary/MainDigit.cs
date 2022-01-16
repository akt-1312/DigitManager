using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitManager.ModelLibrary
{
    public class MainDigit
    {
        [Key]
        public int MainDigitId { get; set; }
       
        [RegularExpression(@"^([0-9])*$", ErrorMessage = "Allow only positive numbers")]
        public string NumStr { get; set; }

        public ShortKey ShortcutType { get; set; }

        public int AmmountOne { get; set; }

        public int AmmountTwo { get; set; }

        public string VoucherId { get; set; }

        public long TotalAmmount { get; set; }

        public DateTime IntendedDate { get; set; }

        public TimeAMOrPM MorningOrEvening { get; set; }

        public int AgentId { get; set; }
        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string DescriptionToShowUser { get; set; }

        public virtual ICollection<SubDigit> SubDigits { get; set; }
    }
}
