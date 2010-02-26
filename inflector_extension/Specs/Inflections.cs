#if DEBUG
using NUnit.Framework;
using SharpTestsEx;

// ReSharper disable InconsistentNaming

namespace inflector_extension.Specs
{
    [TestFixture]
    public class Inflections
    {
        [Test]
        public void ItShouldCamelize()
        {
            "cat_toy".InflectTo().Camelized.Should().Be.EqualTo("catToy");
        }
        
        [Test]
        public void ItShouldCapitalize()
        {
            "cat toy".InflectTo().Capitalized.Should().Be.EqualTo("Cat toy");
        }

        [Test]
        public void ItShouldDasherize()
        {
            "cat_toy".InflectTo().Dasherized.Should().Be.EqualTo("cat-toy");
        }

        [Test]
        public void ItShouldHumanize()
        {
            "cat_toy".InflectTo().Humanized.Should().Be.EqualTo("Cat toy");
        }

        [Test]
        public void ItShouldOrdinalize()
        {
            "5".InflectTo().Ordinalized.Should().Be.EqualTo("5th");
            5.InflectTo().Ordinalized.Should().Be.EqualTo("5th");
        }

        [Test]
        public void ItShouldPluralize()
        {
            "cat".InflectTo().Pluralized.Should().Be.EqualTo("cats");
        }

        [Test]
        public void ItShouldSingularize()
        {
            "cats".InflectTo().Singularized.Should().Be.EqualTo("cat");
        }

        [Test]
        public void ItShouldTitleize()
        {
            "catToy".InflectTo().Titleized.Should().Be.EqualTo("Cat Toy");
        }

        [Test]
        public void ItShouldUnaccent()
        {
            "camión".InflectTo().Unaccented.Should().Be.EqualTo("camion");
        }

        [Test]
        public void ItShouldUncapitalize()
        {
            "Cat Toy".InflectTo().Uncapitalized.Should().Be.EqualTo("cat Toy");
        }

        [Test]
        public void ItShouldUnderscore()
        {
            "catToy".InflectTo().Underscored.Should().Be.EqualTo("cat_toy");
        }
    }
}

// ReSharper restore InconsistentNaming
#endif