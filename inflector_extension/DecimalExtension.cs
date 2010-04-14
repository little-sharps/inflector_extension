using System;
using inflector_extension;
using inflector_extension.Inflector;

// ReSharper disable CheckNamespace
    public static class DecimalExtension
    {
        private static readonly IInflector Inflector = new EnglishInflector();

        public static FluentDecimalInflector InflectTo(this Decimal value)
        {
            return new FluentDecimalInflector(value, Inflector);
        }
    }
    // ReSharper restore CheckNamespace
