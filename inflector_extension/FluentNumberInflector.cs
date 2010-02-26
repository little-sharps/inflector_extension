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
        {0, "zero"},                                                                                                 
        {1, "one"},
        {2, "two"},
        {3, "three"},
        {4, "four"},
        {5, "five"},
        {6, "six"},
        {7, "seven"},
        {8, "eight"},
        {9, "nine"},
        {10, "ten"},
        {11, "eleven"},
        {12, "twelve"},
        {13, "thirteen"},
        {14, "fourteen"},
        {15, "fifteen"},
        {16, "sixteen"},
        {17, "seventeen"},
        {18, "eighteen"},
        {19, "nineteen"}
        };

        private readonly IDictionary<Int64, string> tensCases = new Dictionary<long, string> {
        {2, "twenty"},
        {3, "thirty"},
        {4, "forty"},
        {5, "fifty"},
        {6, "sixty"},
        {7, "seventy"},
        {8, "eighty"},
        {9, "ninety"}};

        private string[] _scaleNumbers = new[] { "", "thousand", "million", "billion" };

        internal FluentNumberInflector(Int64 value, IInflector inflector) {
            this.value = value;
            this.inflector = inflector;
        }

        public string Ordinalized {
            get { return this.inflector.Ordinalize(this.value.ToString()); }
        }

        public string Word {
            get {
                string negativePrefix = "";
                if (value < 0) {
                    negativePrefix = "negative ";
                }
                var absValue = Math.Abs(value);
                return negativePrefix + (this.simpleCases.ContainsKey(absValue) ? this.simpleCases[absValue] : GetNonSimpleName(absValue));
            }
        }

        private string GetNonSimpleName(long absValue) {
            
            var digitSets = GetDigitSets(absValue);

            var setWords = new string[4];

            for (int i = 0; i < 4; i++)
            {
                setWords[i] = ThreeDigitSetToWords(digitSets[i]);
            }

            return CombineWordSets(setWords, digitSets);
        }

        private string CombineWordSets(string[] setWords, long[] digitSets) {
            var combined = setWords[0];
            bool appendAnd;

            // Determine whether an 'and' is needed
            appendAnd = (digitSets[0] > 0) && (digitSets[0] < 100);

            // Process the remaining groups in turn, smallest to largest
            for (int i = 1; i < 4; i++)
            {
                // Only add non-zero items
                if (digitSets[i] != 0)
                {
                    // Build the string to add as a prefix
                    string prefix = setWords[i] + " " + this._scaleNumbers[i];

                    if (combined.Length != 0)
                    {
                        prefix += appendAnd ? " and " : ", ";
                    }

                    // Opportunity to add 'and' is ended
                    appendAnd = false;

                    // Add the three-digit group to the combined string
                    combined = prefix + combined;
                }
            }
            return combined;
        }

        private string ThreeDigitSetToWords(long digitSet) {
            string groupText = "";

            // Determine the hundreds and the remainder
            var hundreds = digitSet / 100;
            var tensUnits = digitSet % 100;

            // Hundreds rules
            if (hundreds != 0)
            {
                groupText += simpleCases[hundreds] + " hundred";

                if (tensUnits != 0)
                {
                    groupText += " and ";
                }
            }

            // Determine the tens and units
            var tens = tensUnits / 10;
            var units = tensUnits % 10;

            // Tens rules
            if (tens >= 2)
            {
                groupText += tensCases[tens];
                if (units != 0)
                {
                    groupText += " " + simpleCases[units];
                }
            }
            else if (tensUnits != 0)
                groupText += simpleCases[tensUnits];

            return groupText;
        }

        private long[] GetDigitSets(long absValue) {
            var digitSets = new long[4];
            for (int i = 0; i < 4; i++) {
                digitSets[i] = absValue % 1000;
                absValue /= 1000;
            }
            return digitSets;
        }
    }
}