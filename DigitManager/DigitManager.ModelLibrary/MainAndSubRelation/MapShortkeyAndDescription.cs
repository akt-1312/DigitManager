using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class MapShortkeyAndDescription
    {
        public static Dictionary<ShortKey, string> GetShortkeyAndDescriptionDictionary()
        {
            Dictionary<ShortKey, string> dictionary = new Dictionary<ShortKey, string>();
            dictionary.Add(ShortKey.TwoEvenNum, "/+");
            dictionary.Add(ShortKey.TwoOddNum, "/-");
            dictionary.Add(ShortKey.TwinEvenNum, "++");
            dictionary.Add(ShortKey.TwinOddNum, "--");
            dictionary.Add(ShortKey.ConcernNum, "*");
            dictionary.Add(ShortKey.ConcernAddTwinNum, "***");
            dictionary.Add(ShortKey.FrontNum, "+");
            dictionary.Add(ShortKey.EndNum, "-");
            dictionary.Add(ShortKey.PowerNum, "*+");
            dictionary.Add(ShortKey.AstrologyNum, "*-");
            dictionary.Add(ShortKey.BrotherNum, "+-");
            dictionary.Add(ShortKey.TwinNum, "**");
            dictionary.Add(ShortKey.DirectNum, ".");
            dictionary.Add(ShortKey.ReverseNum, "/");
            dictionary.Add(ShortKey.RoundAboutNum, "//");
            dictionary.Add(ShortKey.RoundAboutAndTwinNum, "///");
            dictionary.Add(ShortKey.DirectAndReverseNum, "{0}.{1}/{2}");

            return dictionary;
        }
    }
}
