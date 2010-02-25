
using System;

namespace inflector_extension
{


	public static class StringExtension
	{

		private static IInflector Inflector;
		
		public static FluentInflector Inflect (this string value)
		{
			return new FluentInflector (value);
		}

	}
}
