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
        public void ItShouldStartWithInflect ()
        {
        	"test".Inflect();
        }
		
		[Test]
		public void ItShouldReturnAFluentInflector ()
		{
			var result = "foo".Inflect();
			result.GetType().Should().Be.EqualTo(typeof(FluentStringInflector));
		}			

    }
}

// ReSharper restore InconsistentNaming
#endif