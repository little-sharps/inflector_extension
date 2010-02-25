using System;
using inflector_extension.Inflector;

namespace inflector_extension
{
    public class FluentNumberInflector
    {
        private readonly Int64 value;
        private readonly IInflector inflector;

        internal FluentNumberInflector(Int64 value, IInflector inflector)
        {
	        this.value = value;
	        this.inflector = inflector;
	    }

        public string Ordinalized {
            get { return this.inflector.Ordinalize(this.value.ToString()); }
        }
    }
}