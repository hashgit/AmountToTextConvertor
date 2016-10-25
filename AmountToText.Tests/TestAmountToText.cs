using AmountToText.Lib;
using NUnit.Framework;

namespace AmountToText.Tests
{
    [TestFixture]
    public class TestAmountToText
    {
        [TestCase(24350674, "TWENTY FOUR MILLION THREE HUNDRED AND FIFTY THOUSAND SIX HUNDRED AND SEVENTY FOUR DOLLARS")]
        [TestCase(1350671, "ONE MILLION THREE HUNDRED AND FIFTY THOUSAND SIX HUNDRED AND SEVENTY ONE DOLLARS")]
        [TestCase(1050671, "ONE MILLION FIFTY THOUSAND SIX HUNDRED AND SEVENTY ONE DOLLARS")]
        [TestCase(1000001, "ONE MILLION AND ONE DOLLARS")]
        [TestCase(560022, "FIVE HUNDRED AND SIXTY THOUSAND AND TWENTY TWO DOLLARS")]
        [TestCase(60022, "SIXTY THOUSAND AND TWENTY TWO DOLLARS")]
        [TestCase(3013, "THREE THOUSAND AND THIRTEEN DOLLARS")]
        [TestCase(3113, "THREE THOUSAND ONE HUNDRED AND THIRTEEN DOLLARS")]
        [TestCase(113, "ONE HUNDRED AND THIRTEEN DOLLARS")]
        [TestCase(110, "ONE HUNDRED AND TEN DOLLARS")]
        [TestCase(640, "SIX HUNDRED AND FORTY DOLLARS")]
        [TestCase(645, "SIX HUNDRED AND FORTY FIVE DOLLARS")]
        [TestCase(97, "NINETY SEVEN DOLLARS")]
        [TestCase(900, "NINE HUNDRED DOLLARS")]
        [TestCase(9000, "NINE THOUSAND DOLLARS")]
        [TestCase(9900, "NINE THOUSAND NINE HUNDRED DOLLARS")]
        [TestCase(7, "SEVEN DOLLARS")]
        [TestCase(0, "ZERO DOLLARS")]
        [TestCase(0.5, "ZERO DOLLARS AND FIFTY CENTS")]
        [TestCase(0.05, "ZERO DOLLARS AND FIVE CENTS")]
        [Test]
        public void CanConvert(decimal amount, string amountInWords)
        {
            var convertor = new TextConvertor();
            var result = convertor.Convert(amount, "DOLLARS", "CENTS");

            Assert.AreEqual(amountInWords, result);
        }
    }
}
