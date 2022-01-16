using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitManager.ModelLibrary
{
    public class Owner
    {
        public Owner()
        {
            OwnerRefreshTokens = new HashSet<OwnerRefreshToken>();
        }

        [Key]
        public int OwnerId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [RegularExpression(@"^([A-Za-z0-9]{4,30})*$", ErrorMessage = "Not allow whitespace and special characters. Must be between 4 and 30 characters.")]
        public string UserName { get; set; }

        //[Required]
        [RegularExpression(@"^([A-Za-z0-9\S]{5,15})*$", ErrorMessage = "Not allow whitespace. Must be between 5 and 15 characters.")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^(\d{9,12})$", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; }

        [Required]
        public string OwnerGuid { get; set; }

        [Required]
        [Range(65, 90, ErrorMessage = "Lucky Multiply must be between 65 and 90!")]
        public int LuckyMultiply { get; set; }

        [Required]
        [Range(1000,int.MaxValue)]
        public int DefaultMaxAmmountToPlay { get; set; }

        [Required]
        [Range(10, 11)]
        public ushort DeadlineHourAM { get; set; }

        [Required]
        [Range(0,59)]
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

        public virtual ICollection<OwnerRefreshToken> OwnerRefreshTokens { get; set; }

        //[NotMapped]
        //public DateTime DeadlineAM { get; private set; }

        //[NotMapped]
        //public DateTime DeadlinePM { get; private set; }


        //private DateTime GetDeadline(ushort hourAsNumber, ushort minutesAsNumber)
        //{
        //    DateTime dateTime = DateTime.UtcNow.AddMinutes(390).Date + new TimeSpan(hourAsNumber, minutesAsNumber, 0);
        //    return dateTime;
        //}
    }
}
