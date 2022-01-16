using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary
{
    public class OwnerWithToken : Owner
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public OwnerWithToken(Owner owner)
        {
            this.OwnerId = owner.OwnerId;
            this.UserName = owner.UserName;
            this.Mobile = owner.Mobile;
            this.OwnerGuid = owner.OwnerGuid;
            this.LuckyMultiply = owner.LuckyMultiply;
            this.DefaultMaxAmmountToPlay = owner.DefaultMaxAmmountToPlay;
            this.DeadlineHourAM = owner.DeadlineHourAM;
            this.DeadlineMinutesAM = owner.DeadlineMinutesAM;
            this.DeadlineHourPM = owner.DeadlineHourPM;
            this.DeadlineMinutesPM = owner.DeadlineMinutesPM;
            this.IsActive = owner.IsActive;
            this.CreatedData = owner.CreatedData;
            this.UpdatedDate = owner.UpdatedDate;
        }
    }
}
