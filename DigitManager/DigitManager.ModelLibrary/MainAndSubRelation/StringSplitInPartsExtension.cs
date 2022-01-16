using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class StringSplitInPartsExtension
    {
        public static IEnumerable<string> SplitInParts(this string s, int partLength)
        {
            s = s ?? "";
            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
    }
}
