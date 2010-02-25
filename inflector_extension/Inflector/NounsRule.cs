using System.Text.RegularExpressions;

namespace uNhAddIns.Inflector
{
	public class NounsRule : AbstractRule
	{
		public NounsRule(string pattern, string replacement) : base(pattern, replacement) {}

		protected override Regex CreateRegex()
		{
			return new Regex(Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
		}

		public override string Apply(string word)
		{
			if (!Regex.IsMatch(word))
			{
				return null;
			}

			return Regex.Replace(word, Replacement);
		}
	}
}