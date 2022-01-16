using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class ConvertShortkeyToMyanmarNameExtension
    {
        public static string ConvertShortkeyToMyanmarName(this ShortKey shortKey, string numStr)
        {
            string modifiedOneDigitStr = string.Join(",", numStr.SplitInParts(1).ToList());
            string modifiedTwoDigitStr = string.Join(",", numStr.SplitInParts(2).ToList());
            string myanmarName = "စာရိုက်သွင်းမှုမှားယွင်းနေပါသည်";
            switch (shortKey)
            {
                case ShortKey.ConcernAddTwinNum:
                    myanmarName = $"{modifiedOneDigitStr} ပါတ်အပူး {{0}}";
                    break;
                case ShortKey.TwinNum:
                    myanmarName = "အပူး {0}";
                    break;
                case ShortKey.PowerNum:
                    myanmarName = "ပါဝါ {0}";
                    break;
                case ShortKey.AstrologyNum:
                    myanmarName = "နက္ခတ် {0}";
                    break;
                case ShortKey.ConcernNum:
                    myanmarName = $"{modifiedOneDigitStr} ပါတ် {{0}}";
                    break;
                case ShortKey.RoundAboutAndTwinNum:
                    myanmarName = $"{numStr} အပူးအပါခွေ {{0}}";
                    break;
                case ShortKey.RoundAboutNum:
                    myanmarName = $"{numStr} အခွေ {{0}}";
                    break;
                case ShortKey.DirectAndReverseNum:
                    myanmarName = $"{modifiedTwoDigitStr} ဒဲ့ {{0}} R {{1}}";
                    break;
                case ShortKey.ReverseNum:
                    myanmarName = $"{modifiedTwoDigitStr} R {{0}}";
                    break;
                case ShortKey.DirectNum:
                    myanmarName = $"{modifiedTwoDigitStr} ဒဲ့ {{0}}";
                    break;
                case ShortKey.TwoEvenNum:
                    myanmarName = "စုံစုံ {0}";
                    break;
                case ShortKey.TwoOddNum:
                    myanmarName = "မမ {0}";
                    break;
                case ShortKey.TwinEvenNum:
                    myanmarName = "စုံပူး {0}";
                    break;
                case ShortKey.TwinOddNum:
                    myanmarName = "မပူး {0}";
                    break;
                case ShortKey.BrotherNum:
                    myanmarName = "ညီအကို {0}";
                    break;
                case ShortKey.FrontNum:
                    myanmarName = $"{modifiedOneDigitStr} ထိပ် {{0}}";
                    break;
                case ShortKey.EndNum:
                    myanmarName = $"{modifiedOneDigitStr} နောက် {{0}}";
                    break;
                default:
                    break;
            }

            return myanmarName;
        }
    }
}
