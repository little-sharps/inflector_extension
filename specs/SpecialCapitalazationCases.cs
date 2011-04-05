using NUnit.Framework;
using SharpTestsEx;

// ReSharper disable InconsistentNaming

namespace specs
{
    [TestFixture]
    public class SpecialCapitalazationCases
    {
        [Test]
        public void ItShouldCapitalizeSSN()
        {
            var s = "ssn".InflectTo();
            s.Capitalized.Should().Be.EqualTo("SSN");
            s.Titleized.Should().Be.EqualTo("SSN");
        }
    }
}

// ReSharper restore InconsistentNaming