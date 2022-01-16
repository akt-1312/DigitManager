using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary.ViewModels
{
    public class ParamsForRequestSubDigit
    {
        public TimeAMOrPM AmOrPm { get; set; }

        public DateTime IntendedDate { get; set; }

        public int AgentId { get; set; }
    }
}
