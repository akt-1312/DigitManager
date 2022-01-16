using DigitManager.ModelLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Web.Models
{
    public class UserOwner
    {
        [Key]
        public int OwnerId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [RegularExpression(@"^([A-Za-z0-9]{4,30})*$", ErrorMessage = "Not allow whitespace and special characters. Must be between 4 and 30 characters.")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^([A-Za-z0-9\S]{5,15})$", ErrorMessage = "Not allow whitespace. Must be between 5 and 15 characters.")]
        public string Password { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string OwnerGuid { get; set; }

        [Required]
        public int LuckyMultiply { get; set; }

        [Required]
        public int DefaultMaxAmmountToPlay { get; set; }

        [Required]
        [Range(10, 11)]
        public ushort DeadlineHourAM { get; set; }

        [Required]
        [Range(0, 59)]
        public ushort DeadlineMinutesAM { get; set; }

        [Required]
        [Range(3, 4)]
        public ushort DeadlineHourPM { get; set; }

        [Required]
        [Range(0, 59)]
        public ushort DeadlineMinutesPM { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedData { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
