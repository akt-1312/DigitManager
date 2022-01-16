using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class GenerateOriginalInputStringFromMainDigitExtension
    {
        public static string GetOriginalString(this MainDigit mainDigit)
        {
            string originalString = "";
            Dictionary<ShortKey, string> dicShortkeyToSymbol = MapShortkeyAndDescription.GetShortkeyAndDescriptionDictionary();
            switch (mainDigit.ShortcutType)
            {
                case ShortKey.DirectAndReverseNum:
                    originalString = mainDigit.NumStr + dicShortkeyToSymbol[ShortKey.DirectNum] + 
                        mainDigit.AmmountOne.ToString() + dicShortkeyToSymbol[ShortKey.ReverseNum] + 
                        mainDigit.AmmountTwo.ToString();
                    break;
                default:
                    originalString = mainDigit.NumStr + dicShortkeyToSymbol[mainDigit.ShortcutType] + mainDigit.AmmountOne.ToString();
                    break;
            }
            return originalString.StringCompareFormat();
        }
    }
}
