using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary
{
    public class RefreshRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
