using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitManager.ModelLibrary
{
    public class SubDigit
    {
        [Key]
        public int SubDigitId { get; set; }

        [Required]
        [MaxLength(2)]
        public string TwoNum { get; set; }

        [Required]
        public int Ammount { get; set; }

        public int MainDigitId { get; set; }
        [ForeignKey("MainDigitId")]
        public MainDigit MainDigit { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
