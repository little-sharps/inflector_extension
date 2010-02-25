using System;

namespace uNhAddIns.Inflector
{
	public class DataDictionaryRuleApplier: IRuleApplier
	{
		private readonly string className;
		private readonly string dataName;

		public DataDictionaryRuleApplier(string className, string dataName)
		{
			if (className == null)
			{
				throw new ArgumentNullException("className");
			}
			if (dataName == null)
			{
				throw new ArgumentNullException("dataName");
			}
			this.className = className;
			this.dataName = dataName;
		}

		public string Apply(string word)
		{
			return className.Equals(word) ? dataName : null;
		}
	}
}