using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary.MainAndSubRelation
{
    public static class NumStringValidateRegex
    {
        /// <summary>
        /// ***
        /// </summary>
        public const string regexConcernTwin = @"(^[0-9]{1,}\*{3}[0-9]{2,8}$)";
        /// <summary>
        /// **
        /// </summary>
        public const string regexTwin = @"(^\*{2}[0-9]{2,8}$)";
        /// <summary>
        /// *+
        /// </summary>
        public const string regexPower = @"(^\*\+[0-9]{2,8}$)";
        /// <summary>
        /// *-
        /// </summary>
        public const string regexAstrology = @"(^\*\-[0-9]{2,8}$)";
        /// <summary>
        /// *
        /// </summary>
        public const string regexConcern = @"(^[0-9]{1,}\*{1}[0-9]{2,8}$)";
        /// <summary>
        /// ///
        /// </summary>
        public const string regexRoundTwin = @"(^[0-9]{3,7}/{3}[0-9]{2,8}$)";
        /// <summary>
        /// //
        /// </summary>
        public const string regexRound = @"(^[0-9]{3,7}/{2}[0-9]{2,8}$)";
        /// <summary>
        /// /+
        /// </summary>
        public const string regexTwoEven = @"(^/{1}\+{1}[0-9]{2,8}$)";
        /// <summary>
        /// /-
        /// </summary>
        public const string regexTwoOdd = @"(^/{1}\-{1}[0-9]{2,8}$)";
        /// <summary>
        /// ./
        /// </summary>
        public const string regexDirectAndReverse = @"(^[0-9]{2,}\.{1}[0-9]{2,8}/{1}[0-9]{2,8}$)";
        /// <summary>
        /// /
        /// </summary>
        public const string regexReverse = @"(^[0-9]{2,}/{1}[0-9]{2,8}$)";
        /// <summary>
        /// .
        /// </summary>
        public const string regexDirect = @"(^[0-9]{2,}\.{1}[0-9]{2,8}$)";
        /// <summary>
        /// ++
        /// </summary>
        public const string regexTwinEven = @"(^\+{2}[0-9]{2,8}$)";
        /// <summary>
        /// --
        /// </summary>
        public const string regexTwinOdd = @"(^\-{2}[0-9]{2,8}$)";
        /// <summary>
        /// +-
        /// </summary>
        public const string regexBrother = @"(^\+{1}\-{1}[0-9]{2,8}$)";
        /// <summary>
        /// +
        /// </summary>
        public const string regexFront = @"(^[0-9]{1,}\+{1}[0-9]{2,8}$)";
        /// <summary>
        /// -
        /// </summary>
        public const string regexEnd = @"(^[0-9]{1,}\-{1}[0-9]{2,8}$)";
        //public const string regexNumStringValidateRegex = @"(^[0-9]{1,}\*{3}[0-9]{2,8}$)|(^\*{2}[0-9]{2,8}$)|(^\*\+[0-9]{2,8}$)|(^\*\-[0-9]{2,8}$)|(^[0-9]{1,}\*{1}[0-9]{2,8}$)|(^[0-9]{3,7}/{3}[0-9]{2,8}$)|(^[0-9]{3,7}/{2}[0-9]{2,8}$)|(^[0-9]{2,}\.{1}[0-9]{2,8}/{1}[0-9]{2,8}$)|(^[0-9]{2,}/{1}[0-9]{2,8}$)|(^[0-9]{2,}\.{1}[0-9]{2,8}$)|(^\+{2}[0-9]{2,8}$)|(^\-{2}[0-9]{2,8}$)|(^\+{1}\-{1}[0-9]{2,8}$)|(^[0-9]{1,}\+{1}[0-9]{2,8}$)|(^[0-9]{1,}\-{1}[0-9]{2,8}$)";
        public const string regexNumStringValidateRegex = @"(^[0-9]{1,}\*{3}[0-9]{2,8}$)|(^\*{2}[0-9]{2,8}$)|(^\*\+[0-9]{2,8}$)|(^\*\-[0-9]{2,8}$)|(^[0-9]{1,}\*{1}[0-9]{2,8}$)|(^[0-9]{3,7}/{3}[0-9]{2,8}$)|(^[0-9]{3,7}/{2}[0-9]{2,8}$)|(^/{1}\+{1}[0-9]{2,8}$)|(^/{1}\-{1}[0-9]{2,8}$)|(^[0-9]{2,}\.{1}[0-9]{2,8}/{1}[0-9]{2,8}$)|(^[0-9]{2,}/{1}[0-9]{2,8}$)|(^[0-9]{2,}\.{1}[0-9]{2,8}$)|(^\+{2}[0-9]{2,8}$)|(^\-{2}[0-9]{2,8}$)|(^\+{1}\-{1}[0-9]{2,8}$)|(^[0-9]{1,}\+{1}[0-9]{2,8}$)|(^[0-9]{1,}\-{1}[0-9]{2,8}$)";

    }
}
