using AmountToText.Lib;
using System;

namespace AmountToText.Service
{
    public class AmountToTextService : IAmountToTextService
    {
        private readonly ITextConvertor _textConvertor;

        public AmountToTextService(ITextConvertor textConvertor)
        {
            _textConvertor = textConvertor;
        }

        public ConversionResult Convert(ConversionInfo request)
        {
            try
            {
                // read these values from a configuration file?
                var currencyUnit = "DOLLARS";
                var currencyCent = "CENTS";

                var result = _textConvertor.Convert(request.Amount, currencyUnit, currencyCent);
                return new ConversionResult {Text = result, Name = request.Name};
            }
            catch (Exception)
            {
                // log it
                return null;
            }
        }
    }
}
