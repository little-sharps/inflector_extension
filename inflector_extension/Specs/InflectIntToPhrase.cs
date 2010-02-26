#if DEBUG
using System;
using NUnit.Framework;
using SharpTestsEx;

// ReSharper disable InconsistentNaming

namespace inflector_extension.Specs
{
    [TestFixture]
    public class InflectIntToPhrase
    {
        [Test]
        public void ItShouldConvertAllTheNonPatternedNumbers() {
            0.InflectTo().Phrase.Should().Be.EqualTo("zero");
            1.InflectTo().Phrase.Should().Be.EqualTo("one");
            2.InflectTo().Phrase.Should().Be.EqualTo("two");
            3.InflectTo().Phrase.Should().Be.EqualTo("three");
            4.InflectTo().Phrase.Should().Be.EqualTo("four");
            5.InflectTo().Phrase.Should().Be.EqualTo("five");
            6.InflectTo().Phrase.Should().Be.EqualTo("six");
            7.InflectTo().Phrase.Should().Be.EqualTo("seven");
            8.InflectTo().Phrase.Should().Be.EqualTo("eight");
            9.InflectTo().Phrase.Should().Be.EqualTo("nine");
            10.InflectTo().Phrase.Should().Be.EqualTo("ten");
            11.InflectTo().Phrase.Should().Be.EqualTo("eleven");
            12.InflectTo().Phrase.Should().Be.EqualTo("twelve");
        }

        [Test]
        public void ItShouldPrefixNegativeOnNegativeNumbers() {
            (-1).InflectTo().Phrase.Should().Be.EqualTo("negative one");
        }

        private void AssertWord(long number, string word)
        {
            Console.WriteLine(number + " :: " + word);
            number.InflectTo().Phrase.Should().Be.EqualTo(word);
        }

        [TestCase(13, "thirteen")]
        [TestCase(14, "fourteen")]
        [TestCase(15, "fifteen")]
        [TestCase(16, "sixteen")]
        [TestCase(17, "seventeen")]
        [TestCase(18, "eighteen")]
        [TestCase(19, "nineteen")]
        public void ItShouldDoTheTeens(long value, string word)
        {
            AssertWord(value, word);
        }

        [TestCase(20, "twenty")]
        [TestCase(30, "thirty")]
        [TestCase(40, "forty")]
        [TestCase(50, "fifty")]
        [TestCase(60, "sixty")]
        [TestCase(70, "seventy")]
        [TestCase(80, "eighty")]
        [TestCase(90, "ninety")]
        public void ItShouldDoTheTwoDigitBaseNumbers(long value, string word)
        {
            AssertWord(value, word);
        }

        [TestCase(91, "ninety one")]
        [TestCase(45, "forty five")]
        [TestCase(1003, "one thousand and three")]
        [TestCase(5743, "five thousand, seven hundred and forty three")]
        [TestCase(67435, "sixty seven thousand, four hundred and thirty five")]
        [TestCase(637849590678, "six hundred and thirty seven billion, eight hundred and forty nine million, five hundred and ninety thousand, six hundred and seventy eight")]
        public void ItShouldDoAllThese(long value, string word)
        {
            AssertWord(value, word);
        }
    }
}

// ReSharper restore InconsistentNaming
#endif