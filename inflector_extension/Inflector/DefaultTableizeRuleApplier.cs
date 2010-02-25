using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace uNhAddIns.Inflector
{
	public class DefaultTableizeRuleApplier : IRuleApplier
	{
		private readonly IInflector inflector;
		private readonly Regex WhiteSpaces = new Regex(@"[_\s]", RegexOptions.Compiled);

		public DefaultTableizeRuleApplier(IInflector inflector)
		{
			this.inflector = inflector;
		}

		public string Apply(string className)
		{
			var builder = new StringBuilder(className.Length);
			var words = className.SplitWords().ToList();
			var toPluralizeIdx = words.FindLastIndex(word => !WhiteSpaces.IsMatch(word));
			for (int i = 0; i < words.Count; i++)
			{
				var word = words[i];
				if (i == toPluralizeIdx)
				{
					word = inflector.Pluralize(word);
				}
				builder.Append(inflector.Unaccent(word));
			}
			return builder.ToString();
		}
	}
}