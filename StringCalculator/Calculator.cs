using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add(string stringToCalculate)
        {
            if (stringToCalculate == "") return 0;
            
            string[] valuesToSum = FindValues(stringToCalculate);

            return StringsToInt(valuesToSum).Sum();
        }

        private static string[] FindValues(string input)
        {
            string delimiterPattern = @"(?<=\[)(?(?=\D+)[^]]*\D)(?=\])|(?<=\/\/).";
            string exceptionPattern = @"(?<=\[)(?:\d[^]]*|[^]]*\d)(?=\])";
            string standardDelimiters = @"[\n,]+";
            string[] customDelimiters = Regex.Matches(input, delimiterPattern).Select(m => m.Value).ToArray();
            var exceptionDelimiters = Regex.Matches(input, exceptionPattern);
            string substringToSum = Regex.Match(input, @"(?<=\n).*").ToString();

            if (exceptionDelimiters.Count > 0)
            {
                throw new ArgumentException("Delimiters cannot start or end with numbers");
            }

            if (input.Contains("//"))
            {
                return substringToSum.Split(customDelimiters, StringSplitOptions.RemoveEmptyEntries);
            }

            return Regex.Split(input, standardDelimiters);
        }

        private static List<int> StringsToInt(string[] valuesToConvert)
        {
            List<int> posNumbers = new List<int>();
            List<int> negNumbers = new List<int>();
            foreach (string value in valuesToConvert)
            {
                int currentNumber = Int32.Parse(value);
                if (currentNumber >= 0 && currentNumber < 1000)
                {
                    posNumbers.Add(currentNumber);    
                }
                else if (currentNumber < 0)
                {
                    negNumbers.Add(currentNumber);
                }
            }

            if (negNumbers.Count > 0)
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ",negNumbers.ToArray())}");
            }

            return posNumbers;
        }
    }
}
