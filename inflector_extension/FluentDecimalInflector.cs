using System;
using System.Collections.Generic;
using System.Linq;
using inflector_extension.Inflector;

namespace inflector_extension
{
    public class FluentDecimalInflector
    {
        private readonly Decimal value;
        private readonly IInflector inflector;

        public FluentDecimalInflector(Decimal value, IInflector inflector)
        {
            this.value = value;
            this.inflector = inflector;
        }

        public string CheckAmountLongHand
        {
            get
            {
                string result = String.Empty;

                if (value < 0)
                {
                    result += this.inflector.NegativeWord + " ";
                }
                var absValue = Math.Abs(value);

                long wholeNumber = (long)Math.Floor(value);

                result += this.inflector.SimpleNumberCases.ContainsKey(wholeNumber) ? this.inflector.SimpleNumberCases[wholeNumber] : this.GetNonSimpleName(wholeNumber);
                
                decimal cents = Math.Round(value - wholeNumber, 2) * 100;

                result += String.Format(" {0} {1:00}/100", this.inflector.AndWord, cents);
                
                return result;
            }
        }

        private string GetNonSimpleName(long wholeNumber)
        {
            //format to include group number separators, then split on them
            string[] parts = wholeNumber.ToString("N0").Split(new string[] { System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator }, StringSplitOptions.None);

            if(parts.Length > inflector.ScaleNumberWords.Length)
                throw new NotSupportedException(String.Format("Number too large, '{0}' is the largest set supported", inflector.ScaleNumberWords.Last()));

            string[] groupWords = new string[parts.Length];

            for(int i = 0; i < parts.Length; i++)
            {
                groupWords[i] = this.ThreeDigitSetToWords(long.Parse(parts[i]));
            }

            return this.CombineWordGroups(groupWords);
        }

        private string ThreeDigitSetToWords(long digitSet)
        {
            var groupText = "";

            var hundreds = digitSet / 100;
            var tensUnits = digitSet % 100;

            if (hundreds != 0)
            {
                groupText += this.inflector.SimpleNumberCases[hundreds] + " " + this.inflector.HundredsGroupWord + " ";
            }

            var tens = tensUnits / 10;
            var units = tensUnits % 10;

            if (tens >= 2)
            {
                groupText += this.inflector.TensNumberCases[tens];
                if (units != 0)
                    groupText += " " + this.inflector.SimpleNumberCases[units];
            }
            else if (tensUnits != 0)
                groupText += this.inflector.SimpleNumberCases[tensUnits];

            return groupText;
        }

        private string CombineWordGroups(string[] groupWords)
        {
            //var combined = groupWords[0];

            var combined = String.Empty;

            for (var i = 0; i < groupWords.Length; i++)
            {
                if (groupWords[i] != String.Empty)
                {
                    var wordGroup = groupWords[i] + " " + this.inflector.ScaleNumberWords[groupWords.Length - (i + 1)] + " ";

                    combined += wordGroup;
                }
            }
            return combined.Trim();
        }
    }
}
