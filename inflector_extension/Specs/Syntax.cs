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
        public void ItShouldBeStartWithInflect ()
        {
        	"test".Inflect ();
        }
		
		[Test]
		public void ItShouldReturnAFluentInflector ()
		{
			var result = "foo".Inflect ();
			result.GetType().Should().Be.EqualTo(typeof(FluentInflector));
		}			
		
		
    }
}

// ReSharper restore InconsistentNaming
#endif