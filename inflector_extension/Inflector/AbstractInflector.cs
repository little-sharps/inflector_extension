using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace uNhAddIns.Inflector
{
	/// <summary>
	/// Base implementation.
	/// </summary>
	/// <remarks>
	/// Originally implemented by http://andrewpeters.net/inflectornet/
	/// </remarks>
	public abstract class AbstractInflector : IInflector
	{
		private readonly List<IRuleApplier> plurals = new List<IRuleApplier>();
		private readonly List<IRuleApplier> singulars = new List<IRuleApplier>();
		private readonly HashSet<string> uncountables = new HashSet<string>();
		private readonly HashSet<IRuleApplier> unaccentRules = new HashSet<IRuleApplier>();
		private readonly List<IRuleApplier> dataDictionaryRules = new List<IRuleApplier>(50);

		protected AbstractInflector()
		{
			AddUnaccent("([ÀÁÂÃÄÅÆ])", "A");
			AddUnaccent("([Ç])", "C");
			AddUnaccent("([ÈÉÊË])", "E");
			AddUnaccent("([ÌÍÎÏ])", "I");
			AddUnaccent("([Ğ])", "D");
			AddUnaccent("([Ñ])", "N");
			AddUnaccent("([ÒÓÔÕÖØ])", "O");
			AddUnaccent("([ÙÚÛÜ])", "U");
			AddUnaccent("([İ])", "Y");
			AddUnaccent("([Ş])", "T");
			AddUnaccent("([ß])", "s");
			AddUnaccent("([àáâãäåæ])", "a");
			AddUnaccent("([ç])", "c");
			AddUnaccent("([èéêë])", "e");
			AddUnaccent("([ìíîï])", "i");
			AddUnaccent("([ğ])", "e");
			AddUnaccent("([ñ])", "n");
			AddUnaccent("([òóôõöø])", "o");
			AddUnaccent("([ùúûü])", "u");
			AddUnaccent("([ı])", "y");
			AddUnaccent("([ş])", "t");
			AddUnaccent("([ÿ])", "y");

			dataDictionaryRules.Add(new DefaultTableizeRuleApplier(this));
		}

		protected virtual string ApplyFirstMatchRule(IEnumerable<IRuleApplier> rules, string word)
		{
			string result = word;

			if (!uncountables.Contains(word.ToLower()))
			{
				rules.Reverse().First(r => (result = r.Apply(word)) != null);
			}
			return result;
		}

		protected virtual string ApplyRules(IEnumerable<IRuleApplier> rules, string word)
		{
			string result = word;
			foreach (var rule in rules)
			{
				result = rule.Apply(result);
			}
			return result;
		}

		protected virtual void AddIrregular(string singular, string plural)
		{
			AddPlural("(" + singular[0] + ")" + singular.Substring(1) + "$", "$1" + plural.Substring(1));
			AddSingular("(" + plural[0] + ")" + plural.Substring(1) + "$", "$1" + singular.Substring(1));
		}

		protected virtual void AddUncountable(string word)
		{
			uncountables.Add(word.ToLower());
		}

		protected void AddPlural(string rule, string replacement)
		{
			plurals.Add(new NounsRule(rule, replacement));
		}

		protected void AddUnaccent(string rule, string replacement)
		{
			unaccentRules.Add(new CaseSensitiveRule(rule, replacement));
		}

		protected void AddSingular(string rule, string replacement)
		{
			singulars.Add(new NounsRule(rule, replacement));
		}

		public void AddDataDictionary(string className, string dataName)
		{
			AddDataDictionary(new DataDictionaryRuleApplier(className, dataName));
		}

		public void AddDataDictionary(IRuleApplier ruleApplier)
		{
			if (ruleApplier == null)
			{
				throw new ArgumentNullException("ruleApplier");
			}
			dataDictionaryRules.Add(ruleApplier);
		}

		public virtual string Pluralize(string word)
		{
			return ApplyFirstMatchRule(plurals, word);
		}

		public virtual string Singularize(string word)
		{
			return ApplyFirstMatchRule(singulars, word);
		}

		public string Titleize(string word)
		{
			return Regex.Replace(Humanize(Underscore(word)), @"\b([a-z])", match => match.Captures[0].Value.ToUpper());
		}

		public string Humanize(string lowercaseAndUnderscoredWord)
		{
			return Capitalize(Regex.Replace(lowercaseAndUnderscoredWord, @"_", " "));
		}

		public string Pascalize(string lowercaseAndUnderscoredWord)
		{
			return Regex.Replace(lowercaseAndUnderscoredWord, "(?:^|_)(.)", match => match.Groups[1].Value.ToUpper());
		}

		public string Camelize(string lowercaseAndUnderscoredWord)
		{
			return Uncapitalize(Pascalize(lowercaseAndUnderscoredWord));
		}

		public string Underscore(string pascalCasedWord)
		{
			return Regex.Replace(
				Regex.Replace(
					Regex.Replace(pascalCasedWord, @"([A-Z]+)([A-Z][a-z])", "$1_$2"), @"([a-z\d])([A-Z])",
					"$1_$2"), @"[-\s]", "_").ToLower();
		}

		public string Capitalize(string word)
		{
			return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
		}

		public string Uncapitalize(string word)
		{
			return word.Substring(0, 1).ToLower() + word.Substring(1);
		}

		public abstract string Ordinalize(string number);

		public string Dasherize(string underscoredWord)
		{
			return underscoredWord.Replace('_', '-');
		}

		public virtual string Unaccent(string word)
		{
			return ApplyRules(unaccentRules, word);
		}

		public virtual string Tableize(string className)
		{
			return ApplyFirstMatchRule(dataDictionaryRules, className);
		}

		public string ForeignKey(string className, bool separateClassNameAndId)
		{
			return Unaccent(className + (separateClassNameAndId ? "_ID":"Id"));
		}
	}
}