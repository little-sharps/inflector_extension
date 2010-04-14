#if DEBUG
using NUnit.Framework;
using SharpTestsEx;

// ReSharper disable InconsistentNaming

namespace inflector_extension.Specs
{
    [TestFixture]
    public class SpecialCapitalazationCases
    {
        [Test]
        public void ItShouldCapitalizeSSN() {
            var s = "ssn".InflectTo();
            s.Capitalized.Should().Be.EqualTo("SSN");
            s.Titleized.Should().Be.EqualTo("SSN");
        }
    }
}

// ReSharper restore InconsistentNaming
#endif