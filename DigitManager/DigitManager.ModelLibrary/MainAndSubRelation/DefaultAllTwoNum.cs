using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class DefaultAllTwoNum
    {
        public static Dictionary<string, int> ListOfNum()
        {
            Dictionary<string, int> numDic = new Dictionary<string, int>();
            for (int i = 0; i < 100; i++)
            {
                string numString = i.ToString();
                if (numString.Length < 2)
                {
                    numString = "0" + numString;
                }
                numDic.Add(numString, 0);
            }
            return numDic;
        }
        //public static List<TwoNumAndPrice> GetDefaultAllTwoNum()
        //{
        //    List<TwoNumAndPrice> defaultAllTwoNum = new List<TwoNumAndPrice>();
        //    for (short i = 0; i < 100; i++)
        //    {
        //        var twoNum = i.ToString();
        //        twoNum = twoNum.Length > 1 ? twoNum : "0" + twoNum;
        //        TwoNumAndPrice twoNumPrice = new TwoNumAndPrice
        //        {
        //            TwoNumString = twoNum,
        //            Ammount = 0
        //        };
        //        defaultAllTwoNum.Add(twoNumPrice);
        //    }
        //    return defaultAllTwoNum;
        //}

    }
}
