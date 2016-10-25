namespace AmountToText.Lib
{
    public interface ITextConvertor
    {
        string Convert(decimal amount, string unit, string cent);
    }
}
