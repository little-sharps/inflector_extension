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
        public void ItShouldStartWithInflectTo ()
        {
        	"test".InflectTo();
        }
		
		[Test]
		public void ItShouldReturnAFluentInflector ()
		{
			var result = "foo".InflectTo();
			result.GetType().Should().Be.EqualTo(typeof(FluentStringInflector));
		}			

    }
}

// ReSharper restore InconsistentNaming
#endif