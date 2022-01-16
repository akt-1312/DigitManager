using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class IsRegexMatchStringExtension
    {
        public static bool IsMatchWithRegex(this string inputStr, string regexStr)
        {
            Regex regex = new Regex(regexStr, RegexOptions.IgnoreCase);
            return regex.IsMatch(inputStr);
        }
    }
}
