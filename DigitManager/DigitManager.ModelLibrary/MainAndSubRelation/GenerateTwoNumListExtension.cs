using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitManager.ModelLibrary.MainAndSubRelation;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class GenerateTwoNumListExtension
    {

        #region IncludeTotalAmmount
        public static List<TwoNumAndPrice> GenerateTwoNumList(this ShortKey shortKey, string numString, int eachAmmountOne, int eachAmmountTwo, out long totalAmmount)
        {
            numString = numString.StringCompareFormat();
            var reverseString = numString.ReverseString().StringCompareFormat();
            List<TwoNumAndPrice> lstNum = new List<TwoNumAndPrice>();
            TwoNumAndPrice numAndPrice = new TwoNumAndPrice();
            bool isNumStrValid = !string.IsNullOrWhiteSpace(numString) && numString.Length % 2 == 0 ? true : false;

            switch (shortKey)
            {
                #region ဒဲ့
                case ShortKey.DirectNum:
                    lstNum = isNumStrValid ? numString.SplitInParts(2).ToList().Select(x => new TwoNumAndPrice
                    {
                        TwoNumString = x.Trim(),
                        Ammount = eachAmmountOne
                    }).ToList() : null;
                    totalAmmount = lstNum != null ? (uint)lstNum.Count * eachAmmountOne : 0;
                    break;
                #endregion
                #region R
                case ShortKey.ReverseNum:
                    var numStrPlusReverseStr = numString + reverseString;
                    lstNum = isNumStrValid ? numStrPlusReverseStr.SplitInParts(2).ToList().Select(x => new TwoNumAndPrice
                    {
                        TwoNumString = x.Trim(),
                        Ammount = eachAmmountOne
                    }).ToList() : null;
                    totalAmmount = lstNum != null ? (uint)lstNum.Count * eachAmmountOne : 0;
                    break;
                #endregion
                #region ဒဲ့နဲ့R
                case ShortKey.DirectAndReverseNum:
                    if (isNumStrValid)
                    {
                        lstNum.AddRange(numString.SplitInParts(2).ToList().Select(x => new TwoNumAndPrice
                        {
                            TwoNumString = x.Trim(),
                            Ammount = eachAmmountOne
                        }).ToList());
                        totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                        var reverseList = (reverseString.SplitInParts(2).ToList().Select(x => new TwoNumAndPrice
                        {
                            TwoNumString = x.Trim(),
                            Ammount = eachAmmountTwo
                        }).ToList());
                        lstNum.AddRange(reverseList);
                        totalAmmount = totalAmmount + (uint)reverseList.Count * eachAmmountTwo;
                    }
                    else
                    {
                        lstNum = null;
                        totalAmmount = 0;
                    }
                    break;
                #endregion
                #region အပူး
                case ShortKey.TwinNum:
                    for (int i = 0; i <= 9; i++)
                    {
                        lstNum.Add(new TwoNumAndPrice
                        {
                            TwoNumString = i.ToString() + i.ToString(),
                            Ammount = eachAmmountOne
                        });
                    }
                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region ပါတ်
                case ShortKey.ConcernNum:
                    if (numString.Length > 0)
                    {
                        List<string> eachConcernNumList = numString.SplitInParts(1).ToList();
                        foreach (var item in eachConcernNumList)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                bool isTwin = false;
                                lstNum.Add(new TwoNumAndPrice { TwoNumString = item + i.ToString(), Ammount = eachAmmountOne });
                                if (i == int.Parse(item))
                                {
                                    isTwin = lstNum.Any(num => num.TwoNumString.Equals(item + item));
                                }
                                if (!isTwin)
                                {
                                    lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + item, Ammount = eachAmmountOne });
                                }
                            }
                        }
                        totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    }
                    else
                    {
                        lstNum = null;
                        totalAmmount = 0;
                    }
                    break;
                #endregion
                #region ပါတ်ပူး
                case ShortKey.ConcernAddTwinNum:
                    List<string> eachConcernAndTwinList = numString.SplitInParts(1).ToList();
                    foreach (var item in eachConcernAndTwinList)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            lstNum.Add(new TwoNumAndPrice { TwoNumString = item + i.ToString(), Ammount = eachAmmountOne });
                            lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + item, Ammount = eachAmmountOne });
                        }
                    }
                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region အခွေ
                case ShortKey.RoundAboutNum:
                    if (numString.CheckStringCharDuplicate())
                    {
                        lstNum = null;
                        totalAmmount = 0;
                    }
                    else
                    {
                        var eachRoundNumList = numString.SplitInParts(1).ToList();
                        for (int i = 0; i < eachRoundNumList.Count; i++)
                        {
                            for (int j = 0; j < eachRoundNumList.Count; j++)
                            {
                                if (j != i)
                                {
                                    string twoDNum = eachRoundNumList[i] + eachRoundNumList[j];
                                    lstNum.Add(new TwoNumAndPrice { TwoNumString = twoDNum, Ammount = eachAmmountOne });
                                }
                            }
                        }
                        totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    }
                    break;
                #endregion
                #region အပူးပါခွေ
                case ShortKey.RoundAboutAndTwinNum:
                    if (numString.CheckStringCharDuplicate())
                    {
                        lstNum = null;
                        totalAmmount = 0;
                    }
                    else
                    {
                        var eachNumRoundAndTwinList = numString.SplitInParts(1).ToList();
                        for (int i = 0; i < eachNumRoundAndTwinList.Count; i++)
                        {
                            for (int j = 0; j < eachNumRoundAndTwinList.Count; j++)
                            {
                                if (j != i)
                                {
                                    string twoDNum = eachNumRoundAndTwinList[i] + eachNumRoundAndTwinList[j];
                                    lstNum.Add(new TwoNumAndPrice { TwoNumString = twoDNum, Ammount = eachAmmountOne });
                                }
                            }
                            string twinNum = eachNumRoundAndTwinList[i] + eachNumRoundAndTwinList[i];
                            lstNum.Add(new TwoNumAndPrice { TwoNumString = twinNum, Ammount = eachAmmountOne });
                        }
                        totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    }
                    break;
                #endregion
                #region စုံစုံ
                case ShortKey.TwoEvenNum:
                    for (int i = 0; i < 10; i += 2)
                    {
                        for (int j = 0; j < 10; j += 2)
                        {
                            lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + j.ToString(), Ammount = eachAmmountOne });
                        }
                    }
                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region မမ
                case ShortKey.TwoOddNum:
                    for (int i = 1; i < 10; i += 2)
                    {
                        for (int j = 1; j < 10; j += 2)
                        {
                            lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + j.ToString(), Ammount = eachAmmountOne });
                        }
                    }
                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region ထိပ်
                case ShortKey.FrontNum:
                    var eachFrontNumList = numString.SplitInParts(1).ToList();
                    foreach (var eachFrontNum in eachFrontNumList)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            lstNum.Add(new TwoNumAndPrice { TwoNumString = eachFrontNum + i.ToString(), Ammount = eachAmmountOne });
                        }
                    }
                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region နောက်
                case ShortKey.EndNum:
                    var eachEndNumList = numString.SplitInParts(1).ToList();
                    foreach (var eachFrontNum in eachEndNumList)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + eachFrontNum, Ammount = eachAmmountOne });
                        }
                    }
                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region ညီကို
                case ShortKey.BrotherNum:
                    for (int i = 0; i < 10; i++)
                    {
                        string strGreaterNum = i == 9 ? "0" : (i + 1).ToString();
                        lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + strGreaterNum, Ammount = eachAmmountOne });
                        lstNum.Add(new TwoNumAndPrice { TwoNumString = strGreaterNum + i.ToString(), Ammount = eachAmmountOne });
                    }
                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region ပါဝါ
                case ShortKey.PowerNum:
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "05", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "50", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "16", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "61", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "27", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "72", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "38", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "83", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "49", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "94", Ammount = eachAmmountOne });

                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region နက္ခတ်
                case ShortKey.AstrologyNum:
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "07", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "70", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "18", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "81", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "24", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "42", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "35", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "53", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "69", Ammount = eachAmmountOne });
                    lstNum.Add(new TwoNumAndPrice { TwoNumString = "96", Ammount = eachAmmountOne });

                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region စုံပူး
                case ShortKey.TwinEvenNum:
                    for (int i = 0; i < 10; i += 2)
                    {
                        lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + i.ToString(), Ammount = eachAmmountOne });
                    }
                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region မပူး
                case ShortKey.TwinOddNum:
                    for (int i = 1; i < 10; i += 2)
                    {
                        lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + i.ToString(), Ammount = eachAmmountOne });
                    }
                    totalAmmount = (uint)lstNum.Count * eachAmmountOne;
                    break;
                #endregion
                #region အမှား
                default:
                    lstNum = null;
                    totalAmmount = 0;
                    break;
                    #endregion
            }
            return lstNum;
            //_totalAmmount = (uint)(lstNum.Count * eachAmmountOne);
            ////return lstNum;
            //totalAmmount = _totalAmmount;
            //return lstNum;
        }
        #endregion

        //public static List<TwoNumAndPrice> GenerateTwoNumList(this ShortKey shortKey, string numString, uint eachAmmountOne, uint eachAmmountTwo)
        //{
        //    numString = numString.StringCompareFormat();
        //    var reverseString = numString.ReverseString().StringCompareFormat();
        //    List<TwoNumAndPrice> lstNum = new List<TwoNumAndPrice>();
        //    TwoNumAndPrice numAndPrice = new TwoNumAndPrice();
        //    bool isNumStrValid = string.IsNullOrWhiteSpace(numString) && numString.Length % 2 == 0 ? true : false;

        //    switch (shortKey)
        //    {
        //        #region ဒဲ့
        //        case ShortKey.DirectNum:
        //            lstNum = isNumStrValid ? numString.SplitInParts(2).ToList().Select(x => new TwoNumAndPrice
        //            {
        //                TwoNumString = x.Trim(),
        //                Ammount = eachAmmountOne
        //            }).ToList() : null;
        //            break;
        //        #endregion
        //        #region R
        //        case ShortKey.ReverseNum:
        //            var numStrPlusReverseStr = numString + reverseString;
        //            lstNum = isNumStrValid ? numStrPlusReverseStr.SplitInParts(2).ToList().Select(x => new TwoNumAndPrice
        //            {
        //                TwoNumString = x.Trim(),
        //                Ammount = eachAmmountOne
        //            }).ToList() : null;
        //            break;
        //        #endregion
        //        #region ဒဲ့နဲ့R
        //        case ShortKey.DirectAndReverseNum:
        //            if (isNumStrValid)
        //            {
        //                lstNum.AddRange(numString.SplitInParts(2).ToList().Select(x => new TwoNumAndPrice
        //                {
        //                    TwoNumString = x.Trim(),
        //                    Ammount = eachAmmountOne
        //                }).ToList());
        //                var reverseList = (reverseString.SplitInParts(2).ToList().Select(x => new TwoNumAndPrice
        //                {
        //                    TwoNumString = x.Trim(),
        //                    Ammount = eachAmmountTwo
        //                }).ToList());
        //                lstNum.AddRange(reverseList);
        //            }
        //            else
        //            {
        //                lstNum = null;
        //            }
        //            break;
        //        #endregion
        //        #region အပူး
        //        case ShortKey.TwinNum:
        //            for (int i = 0; i <= 9; i++)
        //            {
        //                lstNum.Add(new TwoNumAndPrice
        //                {
        //                    TwoNumString = i.ToString() + i.ToString(),
        //                    Ammount = eachAmmountOne
        //                });
        //            }
        //            break;
        //        #endregion
        //        #region ပါတ်
        //        case ShortKey.ConcernNum:
        //            if (numString.Length > 0)
        //            {
        //                List<string> eachConcernNumList = numString.SplitInParts(1).ToList();
        //                foreach (var item in eachConcernNumList)
        //                {
        //                    for (int i = 0; i < 10; i++)
        //                    {
        //                        bool isTwin = false;
        //                        lstNum.Add(new TwoNumAndPrice { TwoNumString = item + i.ToString(), Ammount = eachAmmountOne });
        //                        if (i == int.Parse(item))
        //                        {
        //                            isTwin = lstNum.Any(num => num.TwoNumString.Equals(item + item));
        //                        }
        //                        if (!isTwin)
        //                        {
        //                            lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + item, Ammount = eachAmmountOne });
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                lstNum = null;
        //            }
        //            break;
        //        #endregion
        //        #region ပါတ်ပူး
        //        case ShortKey.ConcernAddTwinNum:
        //            List<string> eachConcernAndTwinList = numString.SplitInParts(1).ToList();
        //            foreach (var item in eachConcernAndTwinList)
        //            {
        //                for (int i = 0; i < 10; i++)
        //                {
        //                    lstNum.Add(new TwoNumAndPrice { TwoNumString = item + i.ToString(), Ammount = eachAmmountOne });
        //                    lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + item, Ammount = eachAmmountOne });
        //                }
        //            }
        //            break;
        //        #endregion
        //        #region အခွေ
        //        case ShortKey.RoundAboutNum:
        //            if (numString.CheckStringCharDuplicate())
        //            {
        //                lstNum = null;
        //            }
        //            else
        //            {
        //                var eachRoundNumList = numString.SplitInParts(1).ToList();
        //                for (int i = 0; i < eachRoundNumList.Count; i++)
        //                {
        //                    for (int j = 0; j < eachRoundNumList.Count; j++)
        //                    {
        //                        if (j != i)
        //                        {
        //                            string twoDNum = eachRoundNumList[i] + eachRoundNumList[j];
        //                            lstNum.Add(new TwoNumAndPrice { TwoNumString = twoDNum, Ammount = eachAmmountOne });
        //                        }
        //                    }
        //                }
        //            }
        //            break;
        //        #endregion
        //        #region အပူးပါခွေ
        //        case ShortKey.RoundAboutAndTwinNum:
        //            if (numString.CheckStringCharDuplicate())
        //            {
        //                lstNum = null;
        //            }
        //            else
        //            {
        //                var eachNumRoundAndTwinList = numString.SplitInParts(1).ToList();
        //                for (int i = 0; i < eachNumRoundAndTwinList.Count; i++)
        //                {
        //                    for (int j = 0; j < eachNumRoundAndTwinList.Count; j++)
        //                    {
        //                        if (j != i)
        //                        {
        //                            string twoDNum = eachNumRoundAndTwinList[i] + eachNumRoundAndTwinList[j];
        //                            lstNum.Add(new TwoNumAndPrice { TwoNumString = twoDNum, Ammount = eachAmmountOne });
        //                        }
        //                    }
        //                    string twinNum = eachNumRoundAndTwinList[i] + eachNumRoundAndTwinList[i];
        //                    lstNum.Add(new TwoNumAndPrice { TwoNumString = twinNum, Ammount = eachAmmountOne });
        //                }
        //            }
        //            break;
        //        #endregion
        //        #region ထိပ်
        //        case ShortKey.FrontNum:
        //            var eachFrontNumList = numString.SplitInParts(1).ToList();
        //            foreach (var eachFrontNum in eachFrontNumList)
        //            {
        //                for (int i = 0; i < 10; i++)
        //                {
        //                    lstNum.Add(new TwoNumAndPrice { TwoNumString = eachFrontNum + i.ToString(), Ammount = eachAmmountOne });
        //                }
        //            }
        //            break;
        //        #endregion
        //        #region နောက်
        //        case ShortKey.EndNum:
        //            var eachEndNumList = numString.SplitInParts(1).ToList();
        //            foreach (var eachFrontNum in eachEndNumList)
        //            {
        //                for (int i = 0; i < 10; i++)
        //                {
        //                    lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + eachFrontNum, Ammount = eachAmmountOne });
        //                }
        //            }
        //            break;
        //        #endregion
        //        #region ညီကို
        //        case ShortKey.BrotherNum:
        //            for (int i = 0; i < 10; i++)
        //            {
        //                string strGreaterNum = i == 9 ? "0" : (i + 1).ToString();
        //                lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + strGreaterNum, Ammount = eachAmmountOne });
        //                lstNum.Add(new TwoNumAndPrice { TwoNumString = strGreaterNum + i.ToString(), Ammount = eachAmmountOne });
        //            }
        //            break;
        //        #endregion
        //        #region ပါဝါ
        //        case ShortKey.PowerNum:
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "05", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "50", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "16", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "61", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "27", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "72", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "38", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "83", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "49", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "94", Ammount = eachAmmountOne });

        //            break;
        //        #endregion
        //        #region နက္ခတ်
        //        case ShortKey.AstrologyNum:
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "07", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "70", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "18", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "81", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "24", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "42", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "35", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "53", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "69", Ammount = eachAmmountOne });
        //            lstNum.Add(new TwoNumAndPrice { TwoNumString = "96", Ammount = eachAmmountOne });

        //            break;
        //        #endregion
        //        #region စုံစုံ
        //        case ShortKey.TwoEvenNum:
        //            for (int i = 0; i < 10; i += 2)
        //            {
        //                lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + i.ToString(), Ammount = eachAmmountOne });
        //            }
        //            break;
        //        #endregion
        //        #region မမ
        //        case ShortKey.TwoOddNum:
        //            for (int i = 1; i < 10; i += 2)
        //            {
        //                lstNum.Add(new TwoNumAndPrice { TwoNumString = i.ToString() + i.ToString(), Ammount = eachAmmountOne });
        //            }
        //            break;
        //        #endregion
        //        #region အမှား
        //        default:
        //            lstNum = null;
        //            break;
        //            #endregion
        //    }
        //    return lstNum;
        //}



    }
}
