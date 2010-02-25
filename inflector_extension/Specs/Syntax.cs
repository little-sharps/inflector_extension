#if DEBUG
using NUnit.Framework;
using SharpTestsEx;

// ReSharper disable InconsistentNaming

namespace inflector_extension.Specs
{
    [TestFixture]
    public class Syntax
    {
  
        [Test]
        public void ItShouldBeInTheSameNamespaceAsString() {
            var foo = "test".Inflect();
        }
    }
}

// ReSharper restore InconsistentNaming
#endif