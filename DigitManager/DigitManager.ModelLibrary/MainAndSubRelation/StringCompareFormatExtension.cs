using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class StringCompareFormatExtension
    {
        public static string StringCompareFormat(this string compareString)
        {
            if (string.IsNullOrWhiteSpace(compareString))
                return compareString;

            var result = compareString.Replace(" ", string.Empty).ToLower().Trim();
            return result;
        }
    }
}
