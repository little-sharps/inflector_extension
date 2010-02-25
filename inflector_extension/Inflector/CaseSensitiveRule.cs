using System.Text.RegularExpressions;

namespace uNhAddIns.Inflector
{
	public class CaseSensitiveRule : AbstractRule
	{
		public CaseSensitiveRule(string pattern, string replacement) : base(pattern, replacement) {}

		#region Overrides of AbstractRule

		public override string Apply(string word)
		{
			return Regex.Replace(word, Replacement);
		}

		protected override Regex CreateRegex()
		{
			return new Regex(Pattern, RegexOptions.Compiled);
		}

		#endregion
	}
}