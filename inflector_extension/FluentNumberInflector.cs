using System;
using System.Collections.Generic;
using inflector_extension.Inflector;
using System.Linq;

namespace inflector_extension
{
    public class FluentNumberInflector
    {
        private readonly Int64 value;
        private readonly IInflector inflector;

        private readonly IDictionary<Int64, string> simpleCases = new Dictionary<long, string> {
        {0, "Zero"},                                                                                                 
        {1, "One"},
        {2, "Two"},
        {3, "Three"},
        {4, "Four"},
        {5, "Five"},
        {6, "Six"},
        {7, "Seven"},
        {8, "Eight"},
        {9, "Nine"},
        {10, "Ten"},
        {11, "Eleven"},
        {12, "Twelve"},
        {13, "Thirteen"},
        {14, "Fourteen"},
        {15, "Fifteen"},
        {16, "Sixteen"},
        {17, "Seventeen"},
        {18, "Eighteen"},
        {19, "Nineteen"}
        };

        private readonly IDictionary<Int64, string> tensCases = new Dictionary<long, string> {
        {2, "Twenty"},
        {3, "Thirty"},
        {4, "Forty"},
        {5, "Fifty"},
        {6, "Sixty"},
        {7, "Seventy"},
        {8, "Eighty"},
        {9, "Ninety"}};

        private readonly string[] scaleWords = new[] { "", "Thousand", "Million", "Billion" };

        internal FluentNumberInflector(Int64 value, IInflector inflector) {
            this.value = value;
            this.inflector = inflector;
        }

        public string Ordinalized {
            get { return this.inflector.Ordinalize(this.value.ToString()); }
        }

        public string Phrase {
            get {
                var negativePrefix = "";
                if (value < 0) {
                    negativePrefix = "Negative ";
                }
                var absValue = Math.Abs(value);
                return negativePrefix + (this.simpleCases.ContainsKey(absValue) ? this.simpleCases[absValue] : GetNonSimpleName(absValue));
            }
        }

        private string GetNonSimpleName(long absValue) {
            
            var digitSets = GetDigitSets(absValue);
            var setWords = new string[4];

            for (var i = 0; i < 4; i++)
                setWords[i] = ThreeDigitSetToWords(digitSets[i]);

            return CombineWordSets(setWords, digitSets);
        }

        private string CombineWordSets(string[] setWords, long[] digitSets) {
            var combined = setWords[0];
            var appendAnd = ShouldAppendAnAnd(digitSets);

            for (var i = 1; i < 4; i++)
            {
                if (digitSets[i] != 0)
                {
                    var prefix = setWords[i] + " " + this.scaleWords[i];

                    if (combined.Length != 0)
                        prefix += appendAnd ? " and " : ", ";

                    appendAnd = false;

                    combined = prefix + combined;
                }
            }
            return combined;
        }

        private static bool ShouldAppendAnAnd(long[] digitSets) {
            return (digitSets[0] > 0) && (digitSets[0] < 100);
        }

        private string ThreeDigitSetToWords(long digitSet) {
            var groupText = "";

            var hundreds = digitSet / 100;
            var tensUnits = digitSet % 100;

            if (hundreds != 0)
            {
                groupText += simpleCases[hundreds] + " Hundred";

                if (tensUnits != 0)
                    groupText += " and ";
            }

            var tens = tensUnits / 10;
            var units = tensUnits % 10;

            if (tens >= 2)
            {
                groupText += tensCases[tens];
                if (units != 0)
                    groupText += " " + simpleCases[units];
            }
            else if (tensUnits != 0)
                groupText += simpleCases[tensUnits];

            return groupText;
        }

        private static long[] GetDigitSets(long absValue) {
            var digitSets = new long[4];
            for (var i = 0; i < 4; i++) {
                digitSets[i] = absValue % 1000;
                absValue /= 1000;
            }
            return digitSets;
        }
    }
}