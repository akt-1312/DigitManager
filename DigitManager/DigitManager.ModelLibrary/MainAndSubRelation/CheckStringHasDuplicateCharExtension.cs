using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class CheckStringHasDuplicateCharExtension
    {
        public static bool CheckStringCharDuplicate(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return true;
            var set = new HashSet<char>();
            return input.Any(x => !set.Add(x));
        }
    }
}
