namespace AmountToText.Service
{
    public interface IAmountToTextService
    {
        ConversionResult Convert(ConversionInfo request);
    }
}