using System;
using System.Collections.Generic;

namespace AmountToText.Lib
{
    public static class IntegerToWordMapper
    {
        private static readonly IDictionary<int, string> WordMap = new Dictionary<int, string>
        {
            { 0, "ZERO" },
            { 1, "ONE" },
            { 2, "TWO" },
            { 3, "THREE" },
            { 4, "FOUR" },
            { 5, "FIVE" },
            { 6, "SIX" },
            { 7, "SEVEN" },
            { 8, "EIGHT" },
            { 9, "NINE" },
            { 10, "TEN" },
            { 11, "ELEVEN" },
            { 12, "TWELVE" },
            { 13, "THIRTEEN" },
            { 14, "FOURTEEN" },
            { 15, "FIFTEEN" },
            { 16, "SIXTEEN" },
            { 17, "SEVENTEEN" },
            { 18, "EIGHTEEN" },
            { 19, "NINETEEN" },
            { 20, "TWENTY" },
            { 30, "THIRTY" },
            { 40, "FORTY" },
            { 50, "FIFTY" },
            { 60, "SIXTY" },
            { 70, "SEVENTY" },
            { 80, "EIGHTY" },
            { 90, "NINETY" },
            { 100, "HUNDRED" },
            { 1000, "THOUSAND" },
            { 1000000, "MILLION" }
        };

        public static string Map(int number)
        {
            string mapped;
            if (WordMap.TryGetValue(number, out mapped)) return mapped;

            throw new ArgumentOutOfRangeException(nameof(number), $"Unexpected value '{number}'");
        }
    }
}