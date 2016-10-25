using System;
using System.Text;

namespace AmountToText.Lib
{
    public class TextConvertor : ITextConvertor
    {
        public string Convert(decimal amount, string unit, string cent)
        {
            if (amount < 0) // don't know what to do with this?
                throw new FormatException("Number cannot be negative");

            var result = new StringBuilder();
            // a cheque amount has two decimal places
            // Warning: This will convert .999 to 1.0
            var amountFormatted = decimal.Round(amount, 2);

            var integerPart = (int) amountFormatted;
            PerformConversion(integerPart, result, true);
            result.Append($" {unit}");

            var fractionPart = (int) ((amountFormatted - integerPart)*100);
            if (fractionPart <= 0) return result.ToString();

            result.Append(" AND ");
            var fractionResult = new StringBuilder();
            PerformConversion(fractionPart, fractionResult, false);
            result.Append($"{fractionResult} {cent}");

            return result.ToString();
        }

        private static void PerformConversion(int amount, StringBuilder result, bool appendAnd)
        {
            // supporting upto million?
            // can easily add Billion by calling this function with a billion
            amount = ConvertLargePart(amount, result, 1000000);
            amount = ConvertLargePart(amount, result, 1000);
            amount = ConvertLargePart(amount, result, 100);

            if (result.Length > 0 && appendAnd && amount > 0)
            {
                result.Append(" AND ");
            }

            ConvertSmallNumber(amount, result);
        }

        private static int ConvertLargePart(int amount, StringBuilder result, int part)
        {
            var division = amount / part;
            if (division <= 0) return amount;

            if (result.Length > 0 && result[result.Length-1] != ' ') result.Append(" ");

            PerformConversion(division, result, division > 100);
            result.Append($" {IntegerToWordMapper.Map(part)}");
            amount = amount % part;
            return amount;
        }

        // numbers < 100
        private static void ConvertSmallNumber(int amount, StringBuilder result)
        {
            if (amount > 10 && amount < 20)
            {
                result.Append(IntegerToWordMapper.Map(amount));
                return;
            }

            var remainder = amount % 10;
            var division = amount - remainder;
            if (division > 0)
            {
                result.Append(IntegerToWordMapper.Map(division));
            }

            if (remainder == 0)
            {
                if (result.Length == 0)
                {
                    result.Append(IntegerToWordMapper.Map(0));
                }

                return;
            }

            if (division > 0) result.Append(" ");
            result.Append(IntegerToWordMapper.Map(remainder));
        }
    }
}
