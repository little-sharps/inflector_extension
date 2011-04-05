using System;
using NUnit.Framework;
using SharpTestsEx;

// ReSharper disable InconsistentNaming

namespace specs
{
    [TestFixture]
    public class InflectIntToPhrase
    {
        [Test]
        public void ItShouldConvertAllTheNonPatternedNumbers()
        {
            0.InflectTo().Phrase.Should().Be.EqualTo("Zero");
            1.InflectTo().Phrase.Should().Be.EqualTo("One");
            2.InflectTo().Phrase.Should().Be.EqualTo("Two");
            3.InflectTo().Phrase.Should().Be.EqualTo("Three");
            4.InflectTo().Phrase.Should().Be.EqualTo("Four");
            5.InflectTo().Phrase.Should().Be.EqualTo("Five");
            6.InflectTo().Phrase.Should().Be.EqualTo("Six");
            7.InflectTo().Phrase.Should().Be.EqualTo("Seven");
            8.InflectTo().Phrase.Should().Be.EqualTo("Eight");
            9.InflectTo().Phrase.Should().Be.EqualTo("Nine");
            10.InflectTo().Phrase.Should().Be.EqualTo("Ten");
            11.InflectTo().Phrase.Should().Be.EqualTo("Eleven");
            12.InflectTo().Phrase.Should().Be.EqualTo("Twelve");
        }

        [Test]
        public void ItShouldPrefixNegativeOnNegativeNumbers()
        {
            (-1).InflectTo().Phrase.Should().Be.EqualTo("Negative One");
        }

        private void AssertWord(long number, string word)
        {
            Console.WriteLine(number + " :: " + word);
            number.InflectTo().Phrase.Should().Be.EqualTo(word);
        }

        [TestCase(13, "Thirteen")]
        [TestCase(14, "Fourteen")]
        [TestCase(15, "Fifteen")]
        [TestCase(16, "Sixteen")]
        [TestCase(17, "Seventeen")]
        [TestCase(18, "Eighteen")]
        [TestCase(19, "Nineteen")]
        public void ItShouldDoTheTeens(long value, string word)
        {
            AssertWord(value, word);
        }

        [TestCase(20, "Twenty")]
        [TestCase(30, "Thirty")]
        [TestCase(40, "Forty")]
        [TestCase(50, "Fifty")]
        [TestCase(60, "Sixty")]
        [TestCase(70, "Seventy")]
        [TestCase(80, "Eighty")]
        [TestCase(90, "Ninety")]
        public void ItShouldDoTheTwoDigitBaseNumbers(long value, string word)
        {
            AssertWord(value, word);
        }

        [TestCase(91, "Ninety One")]
        [TestCase(45, "Forty Five")]
        [TestCase(1003, "One Thousand and Three")]
        [TestCase(5743, "Five Thousand, Seven Hundred and Forty Three")]
        [TestCase(67435, "Sixty Seven Thousand, Four Hundred and Thirty Five")]
        [TestCase(637849590678, "Six Hundred and Thirty Seven Billion, Eight Hundred and Forty Nine Million, Five Hundred and Ninety Thousand, Six Hundred and Seventy Eight")]
        public void ItShouldDoAllThese(long value, string word)
        {
            AssertWord(value, word);
        }
    }
}

// ReSharper restore InconsistentNaming