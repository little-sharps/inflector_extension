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
            "cat_toy".Inflect().Camelize().Should().Be.EqualTo("catToy");
        }
        
        [Test]
        public void ItShouldCapitalize()
        {
            "cat toy".Inflect().Capitalize().Should().Be.EqualTo("Cat toy");
        }

        [Test]
        public void ItShouldDasherize()
        {
            "cat_toy".Inflect().Dasherize().Should().Be.EqualTo("cat-toy");
        }

        [Test]
        public void ItShouldHumanize()
        {
            "cat_toy".Inflect().Humanize().Should().Be.EqualTo("Cat toy");
        }

        [Test]
        public void ItShouldOrdinalize()
        {
            "5".Inflect().Ordinalize().Should().Be.EqualTo("5th");
            5.Inflect().Ordinalize().Should().Be.EqualTo("5th");
        }

        [Test]
        public void ItShouldPluralize()
        {
            "cat".Inflect().Pluralize().Should().Be.EqualTo("cats");
        }

        [Test]
        public void ItShouldSingularize()
        {
            "cats".Inflect().Singularize().Should().Be.EqualTo("cat");
        }

        [Test]
        public void ItShouldTitleize()
        {
            "catToy".Inflect().Titleize().Should().Be.EqualTo("Cat Toy");
        }

        [Test]
        public void ItShouldUnaccent()
        {
            "camión".Inflect().Unaccent().Should().Be.EqualTo("camion");
        }

        [Test]
        public void ItShouldUncapitalize()
        {
            "Cat Toy".Inflect().Uncapitalize().Should().Be.EqualTo("cat Toy");
        }

        [Test]
        public void ItShouldUnderscore()
        {
            "catToy".Inflect().Underscore().Should().Be.EqualTo("cat_toy");
        }
    }
}

// ReSharper restore InconsistentNaming
#endif