using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class GenerateShortcutTypeAndAmmount
    {
        public static ShortKey GenerateTypeDescripAndAmmount(this string inputStr, out string numStr, out string description
            , out int ammountOne, out int ammountTwo, out long totalAmmount)
        {
            inputStr = inputStr.StringCompareFormat();
            ShortKey shortKey = ShortKey.WrongTyping;
            string _numStr = "";
            string _description = "";
            int _ammountOne = 0;
            int _ammountTwo = 0;
            long _totalAmmount = 0;

            if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexNumStringValidateRegex))
            {
                //ပါတ်ပူး
                if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexConcernTwin))
                {
                    string[] strArray = inputStr.Split(new string[] { "***" }, StringSplitOptions.None);
                    shortKey = ShortKey.ConcernAddTwinNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //အပူး
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexTwin))
                {
                    string[] strArray = inputStr.Split(new string[] { "**" }, StringSplitOptions.None);
                    shortKey = ShortKey.TwinNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //ပါဝါ
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexPower))
                {
                    string[] strArray = inputStr.Split(new string[] { "*+" }, StringSplitOptions.None);
                    shortKey = ShortKey.PowerNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //နက္ခတ်
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexAstrology))
                {
                    string[] strArray = inputStr.Split(new string[] { "*-" }, StringSplitOptions.None);
                    shortKey = ShortKey.AstrologyNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //ပါတ်
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexConcern))
                {
                    string[] strArray = inputStr.Split(new string[] { "*" }, StringSplitOptions.None);
                    shortKey = ShortKey.ConcernNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //အပူးပါခွေ
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexRoundTwin))
                {
                    string[] strArray = inputStr.Split(new string[] { "///" }, StringSplitOptions.None);
                    if (strArray[0].CheckStringCharDuplicate())
                    {
                        shortKey = ShortKey.WrongTyping;
                    }
                    else
                    {
                        _numStr = strArray[0];
                        shortKey = ShortKey.RoundAboutAndTwinNum;
                        _ammountOne = int.Parse(strArray[1]);
                        shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                        _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                    }
                }
                //အခွေ
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexRound))
                {
                    string[] strArray = inputStr.Split(new string[] { "//" }, StringSplitOptions.None);
                    if (strArray[0].CheckStringCharDuplicate())
                    {
                        shortKey = ShortKey.WrongTyping;
                    }
                    else
                    {
                        shortKey = ShortKey.RoundAboutNum;
                        _numStr = strArray[0];
                        _ammountOne = int.Parse(strArray[1]);
                        shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                        _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                    }
                }
                //စုံစုံ
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexTwoEven))
                {
                    string[] strArray = inputStr.Split(new string[] { "/+" }, StringSplitOptions.None);

                    shortKey = ShortKey.TwoEvenNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);

                }
                //မမ
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexTwoOdd))
                {
                    string[] strArray = inputStr.Split(new string[] { "/-" }, StringSplitOptions.None);

                    shortKey = ShortKey.TwoOddNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);

                }
                //ဒဲ့R
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexDirectAndReverse))
                {
                    string[] strArray = inputStr.Split(new string[] { "." }, StringSplitOptions.None);
                    if (strArray[0].StringCompareFormat().Length % 2 != 0)
                    {
                        numStr = _numStr;
                        description = _description;
                        ammountOne = _ammountOne;
                        ammountTwo = _ammountTwo;
                        totalAmmount = _totalAmmount;
                        return shortKey;
                    }
                    shortKey = ShortKey.DirectAndReverseNum;
                    _numStr = strArray[0];
                    string[] strArrayAmmount = strArray[1].Split(new string[] { "/" }, StringSplitOptions.None);
                    _ammountOne = int.Parse(strArrayAmmount[0]);
                    _ammountTwo = int.Parse(strArrayAmmount[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, _ammountTwo, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne, _ammountTwo);
                }
                //R
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexReverse))
                {
                    string[] strArray = inputStr.Split(new string[] { "/" }, StringSplitOptions.None);
                    if (strArray[0].StringCompareFormat().Length % 2 != 0)
                    {
                        numStr = _numStr;
                        description = _description;
                        ammountOne = _ammountOne;
                        ammountTwo = _ammountTwo;
                        totalAmmount = _totalAmmount;
                        return shortKey;
                    }
                    shortKey = ShortKey.ReverseNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //ဒဲ့
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexDirect))
                {
                    string[] strArray = inputStr.Split(new string[] { "." }, StringSplitOptions.None);
                    if (strArray[0].StringCompareFormat().Length % 2 != 0)
                    {
                        numStr = _numStr;
                        description = _description;
                        ammountOne = _ammountOne;
                        ammountTwo = _ammountTwo;
                        totalAmmount = _totalAmmount;
                        return shortKey;
                    }
                    shortKey = ShortKey.DirectNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //စုံပူး
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexTwinEven))
                {
                    string[] strArray = inputStr.Split(new string[] { "++" }, StringSplitOptions.None);
                    shortKey = ShortKey.TwinEvenNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //မပူး
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexTwinOdd))
                {
                    string[] strArray = inputStr.Split(new string[] { "--" }, StringSplitOptions.None);
                    shortKey = ShortKey.TwinOddNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //ညီကို
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexBrother))
                {
                    string[] strArray = inputStr.Split(new string[] { "+-" }, StringSplitOptions.None);
                    shortKey = ShortKey.BrotherNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //ထိပ်
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexFront))
                {
                    string[] strArray = inputStr.Split(new string[] { "+" }, StringSplitOptions.None);
                    shortKey = ShortKey.FrontNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //နောက်
                else if (inputStr.IsMatchWithRegex(NumStringValidateRegex.regexEnd))
                {
                    string[] strArray = inputStr.Split(new string[] { "-" }, StringSplitOptions.None);
                    shortKey = ShortKey.EndNum;
                    _numStr = strArray[0];
                    _ammountOne = int.Parse(strArray[1]);
                    shortKey.GenerateTwoNumList(_numStr, _ammountOne, 0, out _totalAmmount);
                    _description = string.Format(shortKey.ConvertShortkeyToMyanmarName(_numStr), _ammountOne);
                }
                //အမှား
                else
                {
                    numStr = _numStr;
                    description = _description;
                    ammountOne = _ammountOne;
                    ammountTwo = _ammountTwo;
                    totalAmmount = _totalAmmount;
                    return shortKey;
                }
                numStr = _numStr;
                description = _description;
                ammountOne = _ammountOne;
                ammountTwo = _ammountTwo;
                totalAmmount = _totalAmmount;
                if (ammountOne < 25)
                {
                    shortKey = ShortKey.WrongTyping;
                }
                if (shortKey == ShortKey.DirectAndReverseNum)
                {
                    if (ammountTwo < 25)
                    {
                        shortKey = ShortKey.WrongTyping;
                    }
                }
                return shortKey;
            }
            else
            {
                numStr = _numStr;
                description = _description;
                ammountOne = _ammountOne;
                ammountTwo = _ammountTwo;
                totalAmmount = _totalAmmount;
                if (ammountOne < 25)
                {
                    shortKey = ShortKey.WrongTyping;
                }
                if (shortKey == ShortKey.DirectAndReverseNum)
                {
                    if (ammountTwo < 25)
                    {
                        shortKey = ShortKey.WrongTyping;
                    }
                }
                return shortKey;
            }
        }
    }
}
