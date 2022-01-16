using DigitManager.ModelLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class NumStringToMainDigit
    {
        public static MainDigit GetMainDigitByNumString(this string plainNumString, OwnerViewModel model)
        {
            string numStr = "";
            string description = "";
            int ammountOne = 0;
            int ammountTwo = 0;
            long totalAmmount = 0;
            ShortKey shortKey = plainNumString.GenerateTypeDescripAndAmmount(out numStr, out description, out ammountOne, out ammountTwo, out totalAmmount);
            MainDigit mainDigit = new MainDigit
            {
                NumStr = numStr,
                DescriptionToShowUser = description,
                ShortcutType = shortKey,
                AmmountOne = ammountOne,
                AmmountTwo = ammountTwo,
                TotalAmmount = totalAmmount,
                IntendedDate = model.IntendedDate,
                MorningOrEvening = model.TimeAmPM,
                AgentId = model.AgentId,
            };
            return mainDigit;
        }
    }
}
