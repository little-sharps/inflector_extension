using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace uNhAddIns.Inflector
{
	public static class InflectorExtensions
	{
		public const string UppercaseAccentedCharacters = "ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖØÙÚÛÜİŞ";
		public const string LowercaseAccentedCharacters = "ßàáâãäåæçèéêëìíîïğñòóôõöøùúûüışÿ";

		private static readonly Regex WordsSpliter =
			new Regex(string.Format(@"([A-Z{0}]+[a-z{1}\d]*)|[_\s]", UppercaseAccentedCharacters, LowercaseAccentedCharacters),
			          RegexOptions.Compiled);

		public static IEnumerable<string> SplitWords(this string composedPascalCaseWords)
		{
			foreach (Match regex in WordsSpliter.Matches(composedPascalCaseWords))
			{
				yield return regex.Value;
			}
		}
	}
}