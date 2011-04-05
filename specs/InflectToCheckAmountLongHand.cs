using NUnit.Framework;
using SharpTestsEx;

// ReSharper disable InconsistentNaming

namespace specs
{
    [TestFixture]
    public class InflectToCheckAmountLongHand
    {
        [TestCase(13.34, "Thirteen And 34/100")]
        [TestCase(13000.34, "Thirteen Thousand And 34/100")]
        [TestCase(300013.34, "Three Hundred Thousand Thirteen And 34/100")]
        public void ItShouldConvertToTheCorrectPhrase(decimal value, string phrase)
        {
            value.InflectTo().CheckAmountLongHand.Should().Be.EqualTo(phrase);
        }
    }
}

// ReSharper restore InconsistentNaming
